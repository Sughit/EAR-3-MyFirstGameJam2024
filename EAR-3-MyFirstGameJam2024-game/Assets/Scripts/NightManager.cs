using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightManager : MonoBehaviour
{
    [SerializeField] private Light mainLight;
    [SerializeField] private float minHour, maxHour;

    [SerializeField] private float timeIncrease;
    [SerializeField] private float currentHour;

    void Start()
    {
        GameManager.instance.OnForestEnter += ModifyLights;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && GameManager.instance.inForest)
        {
            if(currentHour >= minHour)
            {
                ExitForest();
            }
            else
            {
                NotExitForest();
            }
        }

        if(currentHour >= maxHour)
        {
            Debug.Log("It's time to leave");
            ExitForest();
        }
    }
    
    void FixedUpdate()
    {
        if(GameManager.instance.inForest) currentHour += timeIncrease / Time.deltaTime;
    }

    void NotExitForest()
    {
        Debug.Log("Too early");
    }

    void ExitForest()
    {
        Debug.Log("Exiting forest");
        GameManager.instance.inForest = false;
        currentHour = 0;
    }

    void ModifyLights(object sender, EventArgs e)
    {
        Debug.Log("Getting dark");
        GameManager.instance.inForest = true;
    }
 
}
