using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ShadowCoverControl : MonoBehaviour
{
    public Material playerMaterial;
    public VisualEffect vfx;
    public GameObject[] target;
    public AudioSource absorbAudio;
    public AudioSource releaseAudio;

    PlayerInput playerInput;
    List<GameObject> testList;
    public GameObject shadowTarget;
    Material material;

    float shadowHoldNum;
    float playerMaterialNum;
    float changeLimit = -0.1f;
    float dissolveNum;
    public float distanceCheck;
    public float dissolveSpeed;
    public bool isAbsorb;
    public bool enableSearch;
    bool enableReleaseSearch;
    bool startDissolve;
    bool startRelease;
    bool canIncreaseHoldNum;
    bool canDecreaseHoldNum;
    //bool startRecover;
    bool resetTarget;
    //bool canRelease;
    bool isRelease;
    int shadowCount;
    bool part2;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    private void Start()
    {
        shadowCount = 0;
        dissolveNum = -1.1f;
        playerMaterialNum = 0.5f;
        canDecreaseHoldNum = true;
        canIncreaseHoldNum = true;
       // canRelease = true;
        playerInput.Enable();
        playerInput.Player1.AbsorbShadow.performed += _ => EnableAbsort();
        playerInput.Player1.AbsorbShadow.canceled += _ => DisableAbsort();
        playerInput.Player1.ReleaseShadow.performed += _ => EnableReleaseShadow();
        playerInput.Player1.ReleaseShadow.canceled += _ => DisableReleaseShadow();
        vfx.Stop();
        absorbAudio.enabled = false;
        releaseAudio.enabled = false;
        part2 = false;
    }

    void EnableAbsort()
    {
        enableSearch = true;
    }

    void DisableAbsort()
    {
        enableSearch = false;
        isAbsorb = false;
        startDissolve = false;

        ResetTarget("ShadowCover");
        //target = GameObject.FindGameObjectsWithTag("ShadowCover");
    }

    void EnableReleaseShadow()
    {
       // if (canRelease)
            enableReleaseSearch = true;
    }

    void DisableReleaseShadow()
    {
        //canRelease = false;
        isRelease = false;
        enableReleaseSearch = false;
        startRelease = false;
    }

    void SearchForTarget()
    {
        if (enableSearch)
        {
            dissolveNum = -1.1f;
            target = GameObject.FindGameObjectsWithTag("ShadowCover");
            enableSearch = false;

            if (target.Length > 0)
            {
                isAbsorb = true;
                shadowTarget = target[0];
                float minDistance = Vector3.Distance(transform.position, target[0].transform.parent.position);

                if (target.Length >= 2)
                {

                    for (int i = 0; i < target.Length - 1; i++)
                    {
                        if(Vector3.Distance(transform.position, target[i].transform.parent.position) <= distanceCheck)
                        {
                            if (Vector3.Distance(transform.position, target[i + 1].transform.parent.position) < minDistance)
                            {
                                
                                minDistance = Vector3.Distance(transform.position, target[i + 1].transform.parent.position);
                                shadowTarget = target[i + 1];
                                if (i == target.Length - 1)
                                {
                                    material = shadowTarget.GetComponent<Renderer>().material;
                                    if (shadowTarget.tag == "ShadowCover")
                                        dissolveNum = material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7");
                                    startDissolve = true;
                                    EnableVFX(shadowTarget.transform.position, new Vector3(1, 1, 1), -0.8f, 0f);

                                    shadowHoldNum += 1;

                                    if (dissolveNum >= 0.5f)
                                    {
                                        ResetTarget("ShadowCover");
                                    }
                                }
                            }
                            else
                            {
                                //Debug.Log(minDistance + " " + Vector3.Distance(transform.position, target[i + 1].transform.parent.position));
                                minDistance = Vector3.Distance(transform.position, target[i].transform.parent.position);
                                shadowTarget = target[i];
                                if (i == target.Length - 3 || i == target.Length - 2)
                                {
                                    material = shadowTarget.GetComponent<Renderer>().material;
                                    if (shadowTarget.tag == "ShadowCover")
                                        dissolveNum = material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7");
                                    startDissolve = true;
                                    EnableVFX(shadowTarget.transform.position, new Vector3(1, 1, 1), -0.8f, 0f);

                                    if (dissolveNum >= 0.5f)
                                    {
                                        ResetTarget("ShadowCover");
                                    }
                                    if (canIncreaseHoldNum)
                                    {
                                        canIncreaseHoldNum = false;
                                        shadowHoldNum += 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if((Vector3.Distance(transform.position, target[i + 1].transform.parent.position) <= distanceCheck))
                            {
                                minDistance = Vector3.Distance(transform.position, target[i + 1].transform.parent.position);
                                shadowTarget = target[i + 1];
                                if (i == target.Length - 2)
                                {
                                    material = shadowTarget.GetComponent<Renderer>().material;
                                    if (shadowTarget.tag == "ShadowCover")
                                        dissolveNum = material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7");
                                    startDissolve = true;
                                    EnableVFX(shadowTarget.transform.position, new Vector3(1, 1, 1), -0.8f, 0f);

                                    if (dissolveNum >= 0.5f)
                                    {
                                        ResetTarget("ShadowCover");
                                    }
                                    if (canIncreaseHoldNum)
                                    {
                                        canIncreaseHoldNum = false;
                                        shadowHoldNum += 1;
                                    }
                                }
                            }
                           
                        }
                        
                        
                    }
                }
                else
                {
                    minDistance = Vector3.Distance(transform.position, target[0].transform.parent.position);
                    shadowTarget = target[0];
                    if(Vector3.Distance(transform.position, shadowTarget.transform.parent.position) <= distanceCheck)
                    {
                        material = shadowTarget.GetComponent<Renderer>().material;

                        if (shadowTarget.tag == "ShadowCover")
                            dissolveNum = material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7");
                        startDissolve = true;
                        EnableVFX(shadowTarget.transform.position, new Vector3(1, 1, 1), -0.8f, 0f);
                        if (dissolveNum >= 0.5f)
                        {
                            ResetTarget("ShadowCover");
                        }
                        if (canIncreaseHoldNum)
                        {
                            canIncreaseHoldNum = false;
                            shadowHoldNum += 1;
                        }
                    }
                    
                }
            }
            
            
        }
    }


    void ResetTarget(string name)
    {
/*        if (resetTarget)
        {*/
            //resetTarget = false;
            target = GameObject.FindGameObjectsWithTag(name);
/*        }*/
    }

    void ReleaseShadow()
    {
        if (enableReleaseSearch)
        {
            enableReleaseSearch = false;
            target = GameObject.FindGameObjectsWithTag("ShadowCoverRecover");

            if(target.Length > 0)
            {
                isRelease = true;
                shadowTarget = target[0];
                float minDistance = Vector3.Distance(transform.position, target[0].transform.parent.position);

                if (target.Length >= 2)
                {
                    for (int i = 0; i < target.Length - 2; i++)
                    {
                        if (Vector3.Distance(transform.position, target[i].transform.parent.position) <= distanceCheck)
                        {
                            if (Vector3.Distance(transform.position, target[i + 1].transform.parent.position) < minDistance)
                            {

                                minDistance = Vector3.Distance(transform.position, target[i + 1].transform.parent.position);
                                shadowTarget = target[i + 1];
                                if (i == target.Length - 2)
                                {
                                    material = shadowTarget.GetComponent<Renderer>().material;
                                    startRelease = true;
                                    if (shadowTarget.tag == "ShadowCoverRecover")
                                        dissolveNum = material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7");

                                    EnableVFX(transform.position, new Vector3(-1, 1, 1), 0, 1.2f);
                                    if (canDecreaseHoldNum)
                                    {
                                        canDecreaseHoldNum = false;
                                        shadowHoldNum -= 1;
                                    }

                                    if (dissolveNum <= -1.1f)
                                    {
                                        ResetTarget("ShadowCoverRecover");
                                    }
                                }
                            }
                            else
                            {

                                minDistance = Vector3.Distance(transform.position, target[i].transform.parent.position);
                                shadowTarget = target[i];

                                if (i == target.Length - 3)
                                {
                                    material = shadowTarget.GetComponent<Renderer>().material;
                                    startRelease = true;
                                    if (shadowTarget.tag == "ShadowCoverRecover")
                                        dissolveNum = material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7");

                                    EnableVFX(transform.position, new Vector3(-1, 1, 1), 0, 1.2f);
                                    if (canDecreaseHoldNum)
                                    {
                                        canDecreaseHoldNum = false;
                                        shadowHoldNum -= 1;
                                    }

                                    if (dissolveNum <= -1.1f)
                                    {
                                        ResetTarget("ShadowCoverRecover");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if(Vector3.Distance(transform.position, target[i + 1].transform.parent.position) <= distanceCheck)
                            {
                                minDistance = Vector3.Distance(transform.position, target[i + 1].transform.parent.position);
                                shadowTarget = target[i + 1];

                                if (i == target.Length - 2)
                                {
                                    material = shadowTarget.GetComponent<Renderer>().material;
                                    startRelease = true;
                                    if (shadowTarget.tag == "ShadowCoverRecover")
                                        dissolveNum = material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7");

                                    EnableVFX(transform.position, new Vector3(-1, 1, 1), 0, 1.2f);
                                    if (canDecreaseHoldNum)
                                    {
                                        canDecreaseHoldNum = false;
                                        shadowHoldNum -= 1;
                                    }

                                    if (dissolveNum <= -1.1f)
                                    {
                                        ResetTarget("ShadowCoverRecover");
                                    }
                                }
                            }
                        }
                        
                    }
                }
                else
                {

                    minDistance = Vector3.Distance(transform.position, target[0].transform.parent.position);
                    shadowTarget = target[0];
                    if(Vector3.Distance(transform.position, shadowTarget.transform.parent.position) <= distanceCheck)
                    {
                        material = shadowTarget.GetComponent<Renderer>().material;
                        if (shadowTarget.tag == "ShadowCoverRecover")
                            dissolveNum = material.GetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7");
                        startRelease = true;

                        EnableVFX(transform.position, new Vector3(-1, 1, 1), 0, 1.2f);
                        if (canDecreaseHoldNum)
                        {
                            canDecreaseHoldNum = false;
                            shadowHoldNum -= 1;
                        }
                        if (dissolveNum <= -1.1f)
                        {
                            ResetTarget("ShadowCoverRecover");
                        }
                    }
                    
                }
            }
        }
    }

    void ResetDissolve()
    {
        if(dissolveNum >= 0.5f && isAbsorb)
        {
            //Debug.Log("!");
            shadowTarget.tag = "ShadowCoverRecover";
            //shadowTarget.tag = "Untagged";
            DisableVFX();
            //shadowTarget = null;
        }
        else if(dissolveNum <= -1.1f && isRelease)
        {
            shadowTarget.tag = "ShadowCover";
            //shadowTarget.tag = "Untagged";
            DisableVFX();
        }
    }

    void PlayerShadowCover()
    {
        if (startDissolve && target.Length > 0 && playerMaterialNum > changeLimit)
            playerMaterialNum -= Time.deltaTime * 0.25f;
        else if (startRelease && target.Length > 0 && playerMaterialNum < changeLimit)
            playerMaterialNum += Time.deltaTime * 0.25f;
    }

    void EnableVFX(Vector3 position, Vector3 scale, float xMove, float yMove)
    {
        vfx.Play();
        vfx.transform.position = new Vector3(position.x + xMove, position.y + yMove, position.z);
        vfx.transform.localScale = scale;
    }

    void DisableVFX()
    {
        vfx.Stop();
    }

    private void Update()
    {
        SearchForTarget();
        ResetDissolve();
        ReleaseShadow();
        PlayerShadowCover();
        //ResetTarget();
        //Debug.Log(enableSearch + " " + enableReleaseSearch);
        //Debug.Log(isRelease);
        if (isAbsorb)
        {
            if (dissolveNum < 0.5f && shadowHoldNum == 1)
            {
                changeLimit = -0.06f;
                dissolveNum += Time.deltaTime * dissolveSpeed;
            }
               
            else if(dissolveNum < 0.5f && shadowHoldNum == 2)
            {
                changeLimit = -0.62f;
                dissolveNum += Time.deltaTime * dissolveSpeed;
            }
                
            else if(dissolveNum < 0.5f && shadowHoldNum == 3)
            {
                changeLimit = -1.2f;
                dissolveNum += Time.deltaTime * dissolveSpeed;
            }
                
            else
            {
                isAbsorb = false;
                canIncreaseHoldNum = true;
            }
            absorbAudio.enabled = true;
        }
        else
        {
            absorbAudio.enabled = false;
        }

        if (isRelease)
        {
            if(dissolveNum > -1.1f && shadowHoldNum == 0)
            {
                changeLimit = 0.5f;
                dissolveNum -= Time.deltaTime * dissolveSpeed;
                //   Debug.Log(dissolveNum + " " + shadowHoldNum);
            }

            else if(dissolveNum > -1.1f && shadowHoldNum == 1)
            {
                changeLimit = -0.06f;
                dissolveNum -= Time.deltaTime * dissolveSpeed;
                //  Debug.Log(dissolveNum + " " + shadowHoldNum);
            }

            else if(dissolveNum > -1.1f && shadowHoldNum == 2)
            {
                changeLimit = -0.62f;
                dissolveNum -= Time.deltaTime * dissolveSpeed;
                //Debug.Log(dissolveNum + " " + shadowHoldNum);
            }
            else
            {
                isRelease = false;
                canDecreaseHoldNum = true;
                //Debug.Log(shadowHoldNum);
            }
            releaseAudio.enabled = true;
        }
        else
        {
            releaseAudio.enabled = false;
        }
        if(startDissolve && target.Length > 0)
            material.SetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7", dissolveNum);
        
        if(startRelease && target.Length > 0)
            material.SetFloat("Vector1_fd6c524974304b52bc70bec97b4986d7", dissolveNum);

        playerMaterial.SetFloat("Vector1_3128736e6a0b4a5182a9c2e1b0b5b165", playerMaterialNum);

    }
}
