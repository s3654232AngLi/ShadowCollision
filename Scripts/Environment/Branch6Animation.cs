using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch6Animation : MonoBehaviour
{
    Animator anim;
    Material material;
    public GameObject target;

    bool canActive = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        material = target.GetComponent<Renderer>().material;
    }

    void ActiveMotion()
    {
        if (material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7") >= 0.5f && canActive)
        {
            canActive = false;
            anim.Play("Branch6");
        }
    }

    private void Update()
    {
        ActiveMotion();
    }
}
