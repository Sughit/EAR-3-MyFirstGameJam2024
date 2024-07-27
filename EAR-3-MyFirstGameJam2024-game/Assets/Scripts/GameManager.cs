using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public event EventHandler OnForestEnter; 
    public bool inForest;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !inForest)
        {
            EnterForest();
            OnForestEnter?.Invoke(this, EventArgs.Empty);
        }
    }

    void EnterForest()
    {
        Debug.Log("Forest entered");
        inForest = true;
    }
}
