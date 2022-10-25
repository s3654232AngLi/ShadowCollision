using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCollisionCheck : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player" && other.gameObject.name != "Wall" && other.gameObject.tag != "Ground")
        {
            playerMovement.dir.y = 0;
        }
    }
}
