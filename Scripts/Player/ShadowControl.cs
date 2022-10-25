using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowControl : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerInput playerInput;
    CapsuleCollider col;
    Transform player;
    public Transform handPos;
    bool isHold;
    bool targetCatched;
    Transform target;
    float disX, disY, localScaleX, localScaleY, localScaleZ;
    public Text holdText;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        player = GameObject.Find("Player").transform;
        col = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        playerInput.Enable();
        playerInput.Player2.Hold.performed += _ => HoldShadow();
        playerInput.Player2.Hold.canceled += _ => ReleaseShadow();
    }

    void HoldShadow()
    {
        isHold = true;
    }

    void ReleaseShadow()
    {
        isHold = false;
        targetCatched = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ShadowInteractable")
        {
            target = collision.transform;
            if (isHold)
            {
                targetCatched = true;
                /*disX = transform.position.x - handPos.position.x;
                disY = transform.position.y - handPos.position.y;*/
                holdText.text = "Shadow Hold";
            }
            else
            {
                targetCatched = false;
                holdText.text = "Shadow Released";
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ShadowInteractable")
        {
            target = collision.transform;
            if (isHold)
            {
                targetCatched = true;
                /*disX = transform.position.x - handPos.position.x;
                disY = transform.position.y - handPos.position.y;*/
                holdText.text = "Shadow Hold";
                Debug.Log("Hold");
            }
            else 
            {
                targetCatched = false;
                holdText.text = "Shadow Released";
            }
        }
    }

    private void Update()
    {
        if(target != null)
        {
            if (targetCatched)
            {
                float taegetLocalScale = Mathf.Abs(target.localScale.x);
                target.parent = player;
/*                target.transform.localScale = */
                /*target.transform.position = new Vector3(transform.position.x - disX, transform.position.y - disY, target.position.z);*/
/*                if (!playerMovement.faceToLeft)
                    target.localScale = new Vector3(-taegetLocalScale, target.localScale.y, target.localScale.z);
                else
                    target.localScale = new Vector3(taegetLocalScale, target.localScale.y, target.localScale.z);*/
            }
            else
            {
                return;
            }
        }

        transform.eulerAngles = new Vector3(-16.577f, -88.578f, 179.885f);
        
    }
}
