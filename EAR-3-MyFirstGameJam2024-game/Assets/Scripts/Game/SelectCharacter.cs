using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private GameObject knight, archer, pawn;
    [SerializeField] private Transform spawnPoint;

    public void SelectKnight()
    {
        Instantiate(knight, spawnPoint.position, Quaternion.identity);
        GameManager.instance.playerType = GameManager.PlayerType.Knight;

        GameManager.instance.Init();

        gameObject.SetActive(false);
    }

    public void SelectArcher()
    {
        Instantiate(archer, spawnPoint.position, Quaternion.identity);
        GameManager.instance.playerType = GameManager.PlayerType.Archer;

        GameManager.instance.Init();

        gameObject.SetActive(false);
    }

    public void SelectPawn()
    {
        Instantiate(pawn, spawnPoint.position, Quaternion.identity);
        GameManager.instance.playerType = GameManager.PlayerType.Pawn;  
        
        GameManager.instance.Init();

        gameObject.SetActive(false);
    }
}
