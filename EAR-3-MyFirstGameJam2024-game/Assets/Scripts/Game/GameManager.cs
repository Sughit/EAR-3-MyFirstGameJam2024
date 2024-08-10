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

    [SerializeField] private const float secondsPerDay = 300f;
    public float currentHour;

    public PlayerType playerType;
    [SerializeField] private GameObject knight, archer, pawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioSource audio;
    private bool canta = true;

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
        else Destroy(this.gameObject);

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

        if(SceneManager.GetActiveScene().name == "MainMenu")
            audio.enabled = false;
        else
            audio.enabled = true;

    }

    void FixedUpdate()
    {
        if(inForest) currentHour += Time.deltaTime / secondsPerDay;
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

        SceneManager.LoadScene("MainScene");

        StartCoroutine(SpawnPlayer());
    }

    public void EnterForest()
    {
        Debug.Log("Forest entered");
        inForest = true;

        OnForestEnter?.Invoke(this, EventArgs.Empty);
    }

    IEnumerator SpawnPlayer()
    {
        yield return null;
        switch(playerType)
        {
            case PlayerType.Knight:
            Instantiate(knight, spawnPoint.position, Quaternion.identity);
            Init();
            break;

            case PlayerType.Archer:
            Instantiate(archer, spawnPoint.position, Quaternion.identity);
            Init();
            break;

            case PlayerType.Pawn:
            Instantiate(pawn, spawnPoint.position, Quaternion.identity);
            Init();
            break;

            default:
            break;
        }
    }
}
