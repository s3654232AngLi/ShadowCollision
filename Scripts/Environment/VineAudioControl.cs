using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAudioControl : MonoBehaviour
{
    AudioSource Audio;
    BranchAnimation branchAnimation;
    ShadowCoverControl shadowCoverControl;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        branchAnimation = GameObject.Find("BranchControl").GetComponent<BranchAnimation>();
        shadowCoverControl = GameObject.Find("Player").GetComponent<ShadowCoverControl>();
    }

    void PlayAudio()
    {
        Audio.Play();
    }

    void StopAudio()
    {
        Audio.Stop();
    }

    void EnablePart2()
    {
        branchAnimation.part2 = true;
        shadowCoverControl.distanceCheck = 20f;
    }
}
