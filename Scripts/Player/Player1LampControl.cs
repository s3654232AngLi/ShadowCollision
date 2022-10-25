using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1LampControl : MonoBehaviour
{
    Transform player;
    PlayerMovement playerMovement;
    PlayerInput playerInput;
    PlayerAnimation playerAnimation;
    Player2Animation player2Animation;
    Rigidbody rig;

    public Transform firefly;

    public bool canMove;
    public float moveSpeed;
    public float moveLimit;
    public float distanceLimit;
    public float changeLimit;
    public float changeSpeed;
    public Material playerMaterial;
    float materialNum;

    bool isFar;
    public Text distanceText;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerInput = new PlayerInput();
        playerAnimation = player.GetComponent<PlayerAnimation>();
        player2Animation = GameObject.Find("Firefly").GetComponent<Player2Animation>();
        rig = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerInput.Enable();
        materialNum = 0.5f;
        canMove = true;
    }

    void MoveLamp()
    {
        float leftRightInput = playerInput.Player1.LampLRControl.ReadValue<float>();
        float topDowntInput = playerInput.Player1.LampTDControl.ReadValue<float>();
        float movePosX = transform.position.x + leftRightInput;
        float movePosY = transform.position.y + topDowntInput;

        if (canMove)
        {
            if (Vector3.Distance(player.position, transform.position) < moveLimit)
            {
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePosX, movePosY, transform.position.z), moveSpeed * Time.deltaTime);
                //rig.AddForce(new Vector3(leftRightInput * moveSpeed, topDowntInput * moveSpeed, 0));
                rig.velocity = new Vector3(leftRightInput * moveSpeed, topDowntInput * moveSpeed, 0);
            }
            else
            {
                if (transform.position.x - player.position.x > 0)
                {
                    if (leftRightInput < 0)
                        rig.velocity = new Vector3(leftRightInput * moveSpeed, topDowntInput * moveSpeed, 0);
                    else
                        rig.velocity = new Vector3(0, topDowntInput, 0);
                }

                else if (transform.position.x - player.position.x < 0)
                {
                    if (leftRightInput > 0)
                        rig.velocity = new Vector3(leftRightInput * moveSpeed, topDowntInput * moveSpeed, 0);
                    else
                        rig.velocity = new Vector3(0, topDowntInput, 0);
                }

                else if (transform.position.y - player.position.y > 0)
                {
                    if (topDowntInput < 0)
                        rig.velocity = new Vector3(leftRightInput * moveSpeed, topDowntInput * moveSpeed, 0);
                    else
                        rig.velocity = new Vector3(leftRightInput, 0, 0);
                }

                else if (transform.position.y - player.position.y < 0)
                {
                    if (topDowntInput > 0)
                        rig.velocity = new Vector3(leftRightInput * moveSpeed, topDowntInput * moveSpeed, 0);
                    else
                        rig.velocity = new Vector3(leftRightInput, 0, 0);
                }
                else
                {
                    rig.velocity = new Vector3(0, 0, 0);
                }
            }

            if (leftRightInput > 0)
                firefly.localScale = new Vector3(1, 1, 1);
            else if (leftRightInput < 0)
                firefly.localScale = new Vector3(-1, 1, 1);

            if (leftRightInput == 0 && topDowntInput == 0)
                player2Animation.isFly = false;
            else
                player2Animation.isFly = true;
        }
        else
        {
            player2Animation.isFly = false;
        }
    }

    void DistanceCheck()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        distanceText.text = "Distance: " + distance.ToString("f2") + " Time: " + materialNum.ToString("f2");

        if (materialNum <= changeLimit && !playerAnimation.isDead)
            playerAnimation.isDead = true;

        if (!playerAnimation.isDead)
        {
            if (distance >= distanceLimit)
            {
                isFar = true;
                if (materialNum > changeLimit)
                    materialNum -= Time.deltaTime * changeSpeed;
            }
            else
            {
                isFar = false;
                if (materialNum < 0.5f)
                    materialNum += Time.deltaTime * changeSpeed;
                else
                    materialNum = 0.5f;
            }
        }

    }

    private void Update()
    {
        MoveLamp();
        //DistanceCheck();
        //playerMaterial.SetFloat("Vector1_3128736e6a0b4a5182a9c2e1b0b5b165", materialNum);
    }
}
