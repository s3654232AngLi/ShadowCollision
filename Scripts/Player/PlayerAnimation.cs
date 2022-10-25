using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Animator playerAnim;
    public Transform player1;
    public Transform player2;
    public Transform shadow;
    public bool isInteract;
    public bool isJump;
    public bool isRun;
    public bool isWalk;
    public bool isDead;
    public bool isHighFall;
    Vector3 p1Rotation;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        
    }

    void Run()
    {
        if(isRun && !isInteract)
        {
            playerAnim.Play("Run");
        }
    }

    void Walk()
    {
        if (isWalk && !isInteract)
        {
            playerAnim.Play("Walk");
        }
    }

    void Jump()
    {
        if (isJump && !isInteract)
        {
            isInteract = true;
            playerAnim.Play("Jump");
        }
    }

    void Dead()
    {
        if (isDead)
        {
            isInteract = true;
            playerAnim.Play("Dead");
            EnableDeath();
        }
    }

    void EnableDeath()
    {
        isJump = false;
        isRun = false;
        isWalk = false;
    }

    private void Update()
    {
        playerAnim.SetBool("isRun", isRun);
        playerAnim.SetBool("isWalk", isWalk);
        playerAnim.SetBool("isJump", isJump);
        playerAnim.SetBool("isInteract", isInteract);
        playerAnim.SetBool("isDead", isDead);
        playerAnim.SetBool("isHighFall", isHighFall);
        playerAnim.SetBool("isGround", playerMovement.controller.isGrounded);
        playerAnim.SetFloat("velocity", playerMovement.controller.velocity.y / 10);
        Run();
        Walk();
        Jump();
        Dead();

    }
}
