using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherControl : MonoBehaviour
{
    public Image thunderImage;
    Color newColor;
    float brightColor;
    public Light thunderLight;
    public AudioSource thunder;

    float timer;
    bool isThunder;
    bool thunderFlash;

    private void Start()
    {
        newColor = thunderImage.color;
        newColor.a = 0;
        thunderImage.color = newColor;
        timer = 1f;

        InvokeRepeating("ThunderControl", 1f, 10f);
    }

    void ThunderControl()
    {
        int random = Random.Range(0, 10);

        if (random <= 9)
        {
            StartCoroutine(EnableThunder(1f));
        }
    }

    IEnumerator EnableThunder(float time)
    {
        thunderFlash = true;
        yield return new WaitForSeconds(time);
        thunder.Play();
    }

    private void Update()
    {
        if (isThunder)
        {
            timer -= Time.deltaTime;
            thunderLight.intensity = timer;
            brightColor = timer;
            newColor.a = brightColor;
            thunderImage.color = newColor;

            if (brightColor <= 0)
            {
                isThunder = false;
                thunderFlash = false;
            }

            return;
        }

        

        if(thunderFlash)
        {
            isThunder = true;
            timer = 1.5f;
            thunderLight.intensity = timer;
            brightColor = timer;
        }
    }
}
