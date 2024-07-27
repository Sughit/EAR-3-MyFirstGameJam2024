using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NightManager : MonoBehaviour
{
    [SerializeField] private Light2D mainLight;
    [SerializeField] private float lerpDuration = 1;
    float currentLerp;

    void Start()
    {
        GameManager.instance.OnForestEnter += EnterForest;
        GameManager.instance.OnForestExit += ExitForest;
    }

    void EnterForest(object sender, EventArgs e)
    {
        Debug.Log("Getting dark");

        ChangeLights(1, 0);
    }
 
    void ExitForest(object sender, EventArgs e)
    {
        Debug.Log("Getting light");

        ChangeLights(0, 1);
    }

    IEnumerator ChangeLights(float min, float max)
    {
        while(currentLerp < lerpDuration)
        {
            mainLight.intensity = Mathf.Lerp(min, max, currentLerp / lerpDuration);
            currentLerp += Time.deltaTime;
            yield return null;
        }
    }
}
