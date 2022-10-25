using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class ShadowVFXControl : MonoBehaviour
{
    Transform player;
    VisualEffect vfx;
    int id;

    private void Awake()
    {
        vfx = GetComponent<VisualEffect>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        id = Shader.PropertyToID("PlayerPosition");
    }

    private void Update()
    {
        vfx.SetVector3(id, player.position);
        //Debug.Log(vfx.GetVector3("PlayerPostion"));
    }
}
