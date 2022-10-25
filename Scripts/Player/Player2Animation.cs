using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Animation : MonoBehaviour
{
    public Animator anim;
    public bool isFly;

    private void Awake()
    {
        
    }

    void Fly()
    {
        if (isFly)
        {
            anim.Play("FireflyFly");
        }
    }

    private void Update()
    {
        Fly();
        anim.SetBool("isMove", isFly);
    }
}
