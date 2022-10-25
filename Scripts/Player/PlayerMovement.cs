using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerAnimation playerAnimation;
    public CharacterController controller;

    Rigidbody rig;
    public float movementSpeed;
    public float jumpSpeed;
    float gravity = 9.8f;
    bool isGround;
    bool enableJump;
    bool enableWalk;
    public bool canMove;

    public Vector3 dir;
    public AudioSource moveAudio;
    bool enableMoveAudio;

    public bool faceToRight;
    public bool faceToLeft;
    bool jumpStopInAir;

    //Vector3 playerVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerInput = new PlayerInput();
        rig = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerInput.Enable();
        playerInput.Player1.Jump.performed += _ => Jump();
        playerInput.Player1.Move_Walk.performed += _ => EnableWalk();
        playerInput.Player1.Move_Walk.canceled += _ => DisableWalk();
        canMove = true;
        moveAudio.Play();

    }

    void Move()
    {

            float movementInput = playerInput.Player1.Move.ReadValue<float>();
            dir = new Vector3(movementInput * movementSpeed, dir.y, 0);
            if (movementInput < 0)
            {
                faceToLeft = true;
                faceToRight = false;
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else if (movementInput > 0)
            {
                faceToLeft = false;
                faceToRight = true;
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            if (movementInput != 0)
            {
                if (enableWalk)
                {
                    playerAnimation.isRun = false;
                    playerAnimation.isWalk = true;
                }
                else
                {
                    playerAnimation.isWalk = false;
                    playerAnimation.isRun = true;
                }
            }
            else
            {
                playerAnimation.isWalk = false;
                playerAnimation.isRun = false;
            }
        if (controller.isGrounded && movementInput != 0)
            enableMoveAudio = true;
        else
            enableMoveAudio = false;



    }

    void EnableJump()
    {
        if(!enableJump)
            enableJump = true;
    }
    void Jump()
    {
        if (!playerAnimation.isJump && controller.isGrounded && !playerAnimation.isInteract)
        {
            dir.y = jumpSpeed;
            playerAnimation.isJump = true;
        }
    }

    void EnableWalk()
    {
        enableWalk = true;
        movementSpeed /= 5;
    }

    void DisableWalk()
    {
        enableWalk = false;
        movementSpeed *= 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            enableJump = false;
        }
    }

    private void Update()
    {
        if (!canMove)
        {
            controller.enabled = false;
        }
        else
        {
            controller.enabled = true;
        }

        if (enableMoveAudio)
        {
            moveAudio.enabled = true;
        }
        else
        {
            moveAudio.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            playerAnimation.isJump = false;
        }
        else
        {
            playerAnimation.isJump = true;
        }

        if (!playerAnimation.isDead && canMove)
        {
            Move();
        }

        isGround = controller.isGrounded;

        if (!controller.isGrounded)
        {
            dir.y -= gravity * Time.deltaTime * 3;
        }

        if (controller.velocity.y < -20 && !controller.isGrounded)
        {
            playerAnimation.isHighFall = true;
        }

        /*        if(!playerAnimation.isHighFall && !playerAnimation.isDead)
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }*/

        if (playerAnimation.isDead || playerAnimation.isHighFall)
            dir.x = 0;
        if (!playerAnimation.isDead)
            controller.Move(dir * Time.deltaTime);
    }
}
