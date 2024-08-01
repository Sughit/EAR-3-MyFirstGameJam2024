using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private GameObject knight, archer, pawn;
    [SerializeField] private Transform spawnPoint;
    public bool canSelect = true;
    public static SelectCharacter instance;

    void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainScene") 
        {
            if(canSelect) this.gameObject.SetActive(true);
            else this.gameObject.SetActive(false);
        }
    }

    public void SelectKnight()
    {
        Instantiate(knight, spawnPoint.position, Quaternion.identity);
        GameManager.instance.playerType = GameManager.PlayerType.Knight;

        GameManager.instance.Init();

        gameObject.SetActive(false);

        canSelect = false;
    }

    public void SelectArcher()
    {
        Instantiate(archer, spawnPoint.position, Quaternion.identity);
        GameManager.instance.playerType = GameManager.PlayerType.Archer;

        GameManager.instance.Init();

        gameObject.SetActive(false);

        canSelect = false;
    }

    public void SelectPawn()
    {
        Instantiate(pawn, spawnPoint.position, Quaternion.identity);
        GameManager.instance.playerType = GameManager.PlayerType.Pawn;  
        
        GameManager.instance.Init();

        gameObject.SetActive(false);

        canSelect = false;
    }
}
