using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanMoveControl : MonoBehaviour
{
    PlayerMovement playerMovement;
    BranchAnimation branchAnimation;
    GameObject player;

    private void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        branchAnimation = GameObject.Find("BranchControl").GetComponent<BranchAnimation>();
        player = GameObject.Find("Player");
    }

    public void EnableCanMove()
    {
        branchAnimation.branch5Col2Active = true;
        branchAnimation.branch5Coll2.SetActive(true);
        playerMovement.canMove = true;
        player.transform.parent = null;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0.71f);
    }
}
