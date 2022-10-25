using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowHandControl : MonoBehaviour
{
    Transform player;
    PlayerMovement playerMovement;
    PlayerInput playerInput;

    public float moveSpeed;
    public float moveLimit;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerInput = new PlayerInput();
    }

    private void Start()
    {
        playerInput.Enable();
    }

    void MoveLamp()
    {
        float leftRightInput = playerInput.Player2.HandLRControl.ReadValue<float>();
        float topDowntInput = playerInput.Player2.HandTDControl.ReadValue<float>();
        float movePosX = transform.position.x + leftRightInput;
        float movePosY = transform.position.y + topDowntInput;

            if (Vector3.Distance(player.position, transform.position) < moveLimit)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePosX, movePosY, transform.position.z), moveSpeed * Time.deltaTime);

            }
            else
            {
                if (transform.position.x - player.position.x > 0)
                {
                    if (leftRightInput < 0)
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePosX, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
                }

                else if (transform.position.x - player.position.x < 0)
                {
                    if (leftRightInput > 0)
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePosX, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
                }

                else if (transform.position.y - player.position.y > 0)
                {
                    if (topDowntInput < 0)
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, movePosY, transform.position.z), moveSpeed * Time.deltaTime);
                }

                else if (transform.position.y - player.position.y < 0)
                {
                    if (topDowntInput > 0)
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, movePosY, transform.position.z), moveSpeed * Time.deltaTime);
                }
            }
        
        

        

    }

    private void Update()
    {
        MoveLamp();
    }
}
