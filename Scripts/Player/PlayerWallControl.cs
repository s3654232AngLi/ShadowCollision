using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallControl : MonoBehaviour
{
    Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 1.05f, transform.position.z);
    }
}
