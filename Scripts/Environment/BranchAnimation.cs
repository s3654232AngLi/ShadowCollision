using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchAnimation : MonoBehaviour
{
    PlayerMovement playerMovement;
    public bool part2;

    public Animator anim1, anim2, anim3, anim4, anim5, anim6, anim7, anim8;
    Material material1, material2, material3;

    GameObject player;
    public GameObject branch5Coll2;
    public GameObject branch1Col;
    public GameObject target1, target2, target3;
    public GameObject MountainCol1, MountainCol2, MountainCol3, MountainCol4;

    bool canActive1, canActive2, canActive3, canActive4, canActive5, canActive6, canActive7, canActive8;
    bool colCanActive1, colCanActive2, colCanActive3, colCanActive4;
    public bool branch5Col2Active;

    private void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        player = GameObject.Find("Player");
        material1 = target1.GetComponent<Renderer>().material;
        material2 = target2.GetComponent<Renderer>().material;
        material3 = target3.GetComponent<Renderer>().material;
        canActive1 = true; canActive2 = true; canActive3 = true; canActive4 = true; canActive5 = true; canActive6 = true; canActive7 = true; canActive8 = true;
        colCanActive2 = true; colCanActive3 = true;
        branch5Col2Active = false;
    }

    private void Start()
    {
        MountainCol2.SetActive(false);
        MountainCol3.SetActive(false);
        branch5Coll2.SetActive(false);
        branch1Col.SetActive(false);
        part2 = false;
    }

    void ActiveMotion()
    {
        if (material1.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7") >= 0.5f)
        {
            if (canActive6)
            {
                canActive6 = false;
                anim6.Play("Branch6");
            }
            if (canActive7)
            {
                canActive7 = false;
                anim7.Play("Branch7");
            }
            if (canActive8)
            {
                canActive8 = false;
                anim8.Play("Branch8");
            }
            if (colCanActive2)
            {
                MountainCol2.SetActive(true);
            }
            if (colCanActive3)
            {
                MountainCol3.SetActive(true);
            }
        }

        if(material2.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7") >= 0.5f)
        {
            if (canActive5)
            {
                canActive5 = false;
                anim5.Play("Branch5");
                player.transform.parent = GameObject.Find("PlayerMovePos").transform;
                playerMovement.canMove = false;
                player.transform.position = GameObject.Find("PlayerMovePos").transform.position;

            }
        }

        if(material3.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7") <= -1.1f)
        {
            if (canActive1)
            {
                canActive1 = false;
                anim1.Play("Branch1");
                branch1Col.SetActive(true);
            }
            if (canActive2)
            {
                canActive2 = false;
                anim2.Play("Branch2");
            }
            if (canActive3)
            {
                canActive3 = false;
                anim3.Play("Branch3");
            }
            if (canActive4)
            {
                canActive4 = false;
                anim4.Play("Branch4");
            }
        }
    }

    private void Update()
    {
        ActiveMotion();
        if (part2)
        {
            target1.tag = "Untagged";
            target2.tag = "Untagged";
            target3.tag = "Untagged";
        }
    }
}
