using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public event EventHandler OnForestEnter; 
    [HideInInspector] public event EventHandler OnForestExit;
    public bool inForest;

    [SerializeField] private float minHour, maxHour;

    [SerializeField] private float timeIncrease;
    [SerializeField] private float currentHour;

    public PlayerType playerType;

    public enum PlayerType
    {
        Knight,
        Archer,
        Pawn,
    }

    GameObject lamp;

    void Awake()
    {
        if(instance == null) instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void Init()
    {
        lamp = GameObject.FindWithTag("Lamp");
        if(lamp != null) lamp.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inForest)
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
        if(inForest) currentHour += timeIncrease / Time.deltaTime;
    }

    public void NotExitForest()
    {
        Debug.Log("Too early");
    }

    public void ExitForest()
    {
        Debug.Log("Exiting forest");
        inForest = false;
        currentHour = 0;

        OnForestExit?.Invoke(this, EventArgs.Empty);
    }

    public void EnterForest()
    {
        Debug.Log("Forest entered");
        inForest = true;

        OnForestEnter?.Invoke(this, EventArgs.Empty);
    }
}
