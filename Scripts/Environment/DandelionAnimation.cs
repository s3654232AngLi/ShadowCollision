using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionAnimation : MonoBehaviour
{
    Animator anim;

    Material material;
    public GameObject centerLight;
    public bool centerIsFirefly;

    bool move, moveBack, canMove, canMoveBack;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        material = centerLight.GetComponent<Renderer>().material;
    }

    private void Start()
    {
        canMove = true;
        canMoveBack = false;
    }

    void MoveControl()
    {
        if (material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7") >= 0.5f)
        {
            moveBack = true;
            move = false;
        }
        else if(material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7") <= -1.1f)
        {
            move = true;
            moveBack = false;
        }
        
    }

    void AnimationControl()
    {
        if (canMove && move)
        {
            canMove = false;
            canMoveBack = true;
            anim.Play("BridgeMove");
        }
        else if(canMoveBack && moveBack)
        {
            canMoveBack = false;
            canMove = true;
            anim.Play("BridgeMoveBack");
        }
    }

    private void Update()
    {
        MoveControl();
        AnimationControl();
    }
}
