using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Rigidbody rig;

    bool isActive;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();

    }
    private void Start()
    {
        isActive = true;
    }

    void BallMotion()
    {
        rig.AddForce(new Vector3(1000f,0,0));
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            //isActive = false;
            BallMotion();
        }
    }
    private void Update()
    {
        Debug.Log(isActive);
    }
}
