using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateControl : MonoBehaviour
{
    PlayerAnimation playerAnimation;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerAnimation = GameObject.Find("Player").GetComponent<PlayerAnimation>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    public void ResetInteractState()
    {
        playerAnimation.isInteract = false;
    }

    public void ResetVelocity()
    {
        playerMovement.dir.y = Physics.gravity.y;
    }

    public void EnableHighFall()
    {
        playerAnimation.isHighFall = true;
    }

    public void DisableHighFall()
    {
        playerAnimation.isHighFall = false;
    }
}
