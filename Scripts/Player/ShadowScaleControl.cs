using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScaleControl : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Transform lamp;
    public Transform player;

    int dir;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Start()
    {
        
    }

    void Scale()
    {
        float posY = -(lamp.position.y - 2f) - 0.6f;
        float rotateY = (135 - 90) * (lamp.position.x - player.position.x);
        if(playerMovement.faceToLeft)
            transform.rotation = Quaternion.Euler(0, 90 + rotateY + 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 90 + rotateY, 0);

        transform.localScale = new Vector3(1 + Mathf.Abs(lamp.position.x - player.position.x), 1.8f, 2 + Mathf.Abs(lamp.position.x - player.position.x));
        transform.position = new Vector3(player.position.x - (lamp.position.x - player.position.x), posY, transform.position.z);
    }

    private void Update()
    {
        Scale();
        if (playerMovement.faceToLeft)
            dir = -1;
        else
            dir = 1;

    }
}
