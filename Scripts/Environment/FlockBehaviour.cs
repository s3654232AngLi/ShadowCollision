using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockBehaviour : MonoBehaviour
{
    ShadowColliderGeneration shadowColliderGeneration;
    Player1LampControl player1LampControl;
    ShadowCoverControl shadowCoverControl;

    public Transform dandelion;
    public Transform firelfy;
    public Transform player;
    public Transform centerTrigger;
    Transform newCenter;

    Light dandelionLight;
    Light fireflyLight;
    Transform center;
    public Transform[] follows;
    public Transform[] dandelionCenter;

    Vector3[] target;
    Vector3[] targetAfterRandom;
    public float distance;
    bool enableRandomize;
    float minDistance = 100f;
    bool canActive = true;
    bool activeDandelion;

    public GameObject col1;
    public GameObject col2;
    bool canCol1;
    bool canCol2;
    public Transform activePos1;
    public Transform activePos2;

    private void Awake()
    {
        shadowColliderGeneration = GameObject.Find("Firefly").GetComponent<ShadowColliderGeneration>();
        player1LampControl = GameObject.Find("Firefly").GetComponent<Player1LampControl>();
        shadowCoverControl = GameObject.Find("Player").GetComponent<ShadowCoverControl>();

        center = dandelion;
        target = new Vector3[follows.Length];
        targetAfterRandom = new Vector3[follows.Length];
    }

    private void Start()
    {
        enableRandomize = true;
        dandelionLight = dandelion.gameObject.GetComponentInChildren<Light>();
        fireflyLight = firelfy.gameObject.GetComponentInChildren<Light>();
        newCenter = dandelionCenter[0];
        canCol1 = true;
        canCol2 = true;
        col1.SetActive(false);
        col2.SetActive(false);
    }

    void RandomizeTarget()
    {

        for (int i = 0; i < targetAfterRandom.Length; i++)
        {
            Vector3 pos = targetAfterRandom[i];
            int random = Random.Range(0, i);
            targetAfterRandom[i] = targetAfterRandom[random];
            targetAfterRandom[random] = pos;
            if(i >= targetAfterRandom.Length - 1)
            {
                enableRandomize = true;
            }
        }
        
    }

    void TargetTrack()
    {
        for(int i = 0; i < target.Length; i++)
        {
            target[i] = PostionHandle(distance, i, 6, center.position);
            targetAfterRandom[i] = target[i];
        }
    }

    void FollowTarget()
    {
        for (int i = 0; i < targetAfterRandom.Length; i++)
        {
            if(Vector3.Distance(follows[i].position, targetAfterRandom[i]) > 0f) 
            {
                float speed = Vector3.Distance(follows[i].position, targetAfterRandom[i]);
                follows[i].position = Vector3.MoveTowards(follows[i].position, targetAfterRandom[i], Time.deltaTime * speed * 2);
                follows[i].LookAt(center);
            }
        }
    }

    Vector3 PostionHandle(float dis, float n, float b, Vector3 cen)
    {
        Vector3 cal = new Vector3(dis * Mathf.Sin((Mathf.PI / 180) * Mathf.Round(360 / b) * n) + cen.x, dis * Mathf.Cos((Mathf.PI / 180) * Mathf.Round(360 / b) * n) + cen.y, cen.z);
        return cal;
    }

    void CenterControl()
    {
        for (int i = 0; i < dandelionCenter.Length; i++)
        {
            float danAndPlayerDistance = Vector3.Distance(dandelionCenter[i].position, player.position);
            if (danAndPlayerDistance < minDistance)
            {
                minDistance = danAndPlayerDistance;
                newCenter = dandelionCenter[i];
            }
        }

        if (newCenter.tag == "ShadowCover")
        {
            center = firelfy;
            shadowColliderGeneration.skillBlock = true;
            player1LampControl.canMove = true;


            /*            if(dandelionLight.intensity > 0)
                        {
                            dandelionLight.intensity -= Time.deltaTime * 10;
                        }
                        else
                        {
                            dandelionLight.intensity = 0;
                        }

                        if(fireflyLight.intensity > 1f)
                        {
                            fireflyLight.intensity -= Time.deltaTime * 100;
                        }*/
        }
        else
        {
            center = newCenter;


            //center = shadowCoverControl.shadowTarget.transform;
            shadowColliderGeneration.skillBlock = false;

            /*            if (dandelionLight.intensity < 20)
                        {
                            dandelionLight.intensity += Time.deltaTime * 10;
                        }
                        else
                        {
                            dandelionLight.intensity = 20;
                        }

                        if (fireflyLight.intensity < 3.5f)
                        {
                            fireflyLight.intensity += Time.deltaTime * 100;
                        }*/

        }
    }

    void ActiveCol1()
    {
        if (canCol1 && player.position.x - activePos1.position.x > 0.1f && Mathf.Abs(player.position.y - activePos1.position.y) < 1f)
        {
            canCol1 = false;
            col1.SetActive(true);
        }
    }

    void ActiveCol2()
    {
        if (canCol2 && player.position.x - activePos2.position.x < -0.1f && Mathf.Abs(player.position.y - activePos2.position.y) < 1f)
        {
            canCol2 = false;
            col2.SetActive(true);
        }
    }

    private void Update()
    {
        if(activeDandelion)
            CenterControl();
        if(Vector3.Distance(dandelionCenter[0].transform.position, player.position) <= 10f && canActive)
        {
            canActive = false;
            activeDandelion = true;
        }

        ActiveCol1();
        ActiveCol2();
    }

    private void FixedUpdate()
    {
        if (activeDandelion)
        {
            TargetTrack();
            FollowTarget();
        }
        
    }
}
