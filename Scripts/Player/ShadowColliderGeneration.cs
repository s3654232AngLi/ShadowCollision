using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShadowColliderGeneration : MonoBehaviour
{
    PlayerInput playerInput;
    Player1LampControl player1LampControl;

    public bool skillBlock;
    GameObject[] shadowPlane = new GameObject[360];
    public GameObject shadowGroundObj;
    public LayerMask shadowLayer;
    public LayerMask groundLayer;
    public LayerMask hitLayer;
    public Mesh groundMesh;
    public GameObject groundCollider;
    public bool enableMeshRenderer;
    bool canInstantiate;
    bool isActiveShadowGround;
    bool canDestroy;
    bool isMoving;


    private void Awake()
    {
        playerInput = new PlayerInput();
        player1LampControl = GameObject.Find("Firefly").GetComponent<Player1LampControl>();
        skillBlock = false;
    }

    private void Start()
    {
        //GenerateLightShoot();
        playerInput.Enable();
        playerInput.Player2.GenerateShadowGround.performed += _ => EnableShadowGround();
        playerInput.Player2.GenerateShadowGround.canceled += _ => DisableShadowGround();
        canInstantiate = true;
    }

    void EnableShadowGround()
    {
        if (!skillBlock)
        {
            canDestroy = false;
            isActiveShadowGround = true;
            player1LampControl.canMove = false;
        }
        else
            player1LampControl.canMove = true;
    }

    void DisableShadowGround()
    {
        canDestroy = true;
        isActiveShadowGround = false;
        player1LampControl.canMove = true;
    }

    void GenerateLightShoot()
    {
        if (!skillBlock && canInstantiate)
        {
            bool stopInstantiate = false;
            canInstantiate = false;
            for (int i = 0; i < 360; i++)
            {
                var ray = new Ray(transform.position, Quaternion.AngleAxis(i, transform.up) * transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000f, shadowLayer))
                {
                    if (hit.transform.tag == "ShadowInteractable")
                    {
                        hit.transform.gameObject.layer = 15;
                        var groundCheck = new Ray(hit.point, Quaternion.AngleAxis(i, transform.up) * transform.forward);
                        RaycastHit groundHit;
                        if (Physics.Raycast(groundCheck, out groundHit, 1000f, groundLayer) && !stopInstantiate)
                        {
                            if(Vector3.Distance(hit.point, groundHit.point) > 0)
                            {
                                shadowPlane[i] = InstantiateGround(hit.point, groundHit.point, i);
                                GameObject collider = Instantiate(groundCollider, new Vector3((hit.point.x + groundHit.point.x) / 2, (hit.point.y + groundHit.point.y) / 2, hit.point.z), Quaternion.AngleAxis(i, new Vector3(0,0,1)), shadowPlane[i].transform);
                                collider.transform.localScale = new Vector3(0.01f, Vector3.Distance(hit.point, groundHit.point), 2);
                            }
                            else
                            {
                                //Debug.Log(hit.point + " " + groundHit.point);
                            }
                        }
                        else if (Physics.Raycast(groundCheck, out groundHit, 1000f, shadowLayer) && !stopInstantiate)
                        {
                            if (Vector3.Distance(hit.point, groundHit.point) > 0)
                            {
                                shadowPlane[i] = InstantiateGround(hit.point, groundHit.point, i);
                                GameObject collider = Instantiate(groundCollider, new Vector3((hit.point.x + groundHit.point.x) / 2, (hit.point.y + groundHit.point.y) / 2, hit.point.z), Quaternion.AngleAxis(i, new Vector3(0, 0, 1)), shadowPlane[i].transform);
                                collider.transform.localScale = new Vector3(0.01f, Vector3.Distance(hit.point, groundHit.point), 2);
                            }
                            else
                            {
                                Debug.Log(Vector3.Distance(hit.point, groundHit.point));
                            }
                        }
                        Debug.DrawRay(hit.point, Quaternion.AngleAxis(i, transform.up) * transform.forward * 3f, Color.blue);
                        if (i >= 360)
                        {
                            stopInstantiate = true;
                        }
                        hit.transform.gameObject.layer = 12;
                    }

                }
                else
                {
                    Debug.DrawRay(transform.position, Quaternion.AngleAxis(i, transform.up) * transform.forward * 3f, Color.red);
                }
                if(i == 359)
                {
                    //StartCoroutine(WaitForSec(0.01f));
                }
            }
            
        }
    }

    IEnumerator WaitForSec(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("360");

        for (int i = 0; i < 360; i++)
        {
            if (shadowPlane[i] != null)
                Destroy(shadowPlane[i]);
        }
        canInstantiate = true;
    }

    void DestroyShadowGround()
    {
        if (skillBlock)
        {
            for (int i = 0; i < 360; i++)
            {
                if (shadowPlane[i] != null)
                    Destroy(shadowPlane[i]);
            }
            canInstantiate = true;
            isActiveShadowGround = false;
        }
        else
        {
            if (!canInstantiate && canDestroy)
            {
                for (int i = 0; i < 360; i++)
                {
                    if (shadowPlane[i] != null)
                        Destroy(shadowPlane[i]);
                }
                canInstantiate = true;
            }
            
        }
    }

    GameObject InstantiateGround(Vector3 start, Vector3 end, int angle)
    {
        GameObject plane = new GameObject("Plane");
        MeshFilter mf = plane.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mt = plane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();
        m.vertices = new Vector3[]
        {
            new Vector3(start.x,start.y,start.z + 1),
            new Vector3(start.x, start.y, start.z - 1),
            new Vector3(end.x, end.y, end.z - 1),
            new Vector3(end.x, end.y, end.z + 1)
        };

        m.uv = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)
        };

        m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        if (angle < 180)
        {
            m.triangles = m.triangles.Reverse().ToArray();
        }

        mf.mesh = m;
        //if (m.vertices.Distinct().Count() >= 3)
        //(plane.AddComponent(typeof(MeshCollider)) as MeshCollider).sharedMesh = m;
        //plane.AddComponent<BoxCollider>();
        if(!enableMeshRenderer)
            plane.GetComponent<MeshRenderer>().enabled = false;

        plane.layer = 13;

        m.RecalculateBounds();
        m.RecalculateNormals();

        //Debug.Log(m.vertices.Distinct().Count());
        return plane;
    }

    private void Update()
    {
        if (isActiveShadowGround)
        {
            GenerateLightShoot();
        }

        DestroyShadowGround();
    }
}
