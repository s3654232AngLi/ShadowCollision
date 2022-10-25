using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public GameObject col;
    public GameObject[] tree;
    public Animator[] treeAnim;
    public bool activeTree;
    bool canEnableTrigger;
    public float enableDistance;
    public GameObject trigger;
    Transform player;
    Material triggerMaterial;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        col.SetActive(false);
    }

    private void Start()
    {
        canEnableTrigger = true;
        triggerMaterial = trigger.GetComponent<Renderer>().material;
    }
    void ActiveTreeMotion()
    {
        if (activeTree)
        {
            activeTree = false;
            for(int i = 0; i < treeAnim.Length; i++)
            {
                treeAnim[i].Play("TreeMotion");
            }
            col.SetActive(true);
        }
    }

    void EnableTrigger()
    {
        if(canEnableTrigger && triggerMaterial.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7") <= -1.1f)
        {
            canEnableTrigger = false;
            activeTree = true;
        }
    }

    void DisableTrigger()
    {
        
    }

    private void Update()
    {
        ActiveTreeMotion();
        EnableTrigger();
    }
}
