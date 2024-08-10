using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager instance;

    //Sa vedem cate constructii avem in nivel
    int numHouses, numMines, numTowers;

    //Sa vedem cate iteme/constructii trebuie sa colectam/distrugem (trebuie accesate de alte script-uri)
    public int numWood, numMeat, numGold;
    public int numHousesToDestroy, numTowersToDestroy, numMinesToDestroy;

    //Variabile pt algoritmul de alegere a itemelor de colectat
    [SerializeField] int woodCost, meatCost, goldCost;
    [SerializeField] int price;
    [SerializeField] int iterations;

    //Variabile pt UI
    [SerializeField] Transform placeToSpawnObjective;
    [SerializeField] TMP_Text objectiveTitle;
    [SerializeField] GameObject objectiveGOBuilding, objectiveGOItem;
    [SerializeField] Sprite woodSprite, meatSprite, goldSprite, houseSprite, mineSprite, towerSprite;

    //Variabile pt fiecare GO care are cladirea/itemul
    private GameObject woodGO, meatGO, goldGO, houseGO, mineGO, towerGO;

    //Variabila de decizie a obiectivului
    int index;
    public ObjectiveType objectiveType;
    public enum ObjectiveType
    {
        DestroyBuildings,
        CollectItems,
    }

    void Awake()
    {
        instance = this;
    }

    public void GetInfoAboutLevel()
    {
        numHouses = GameObject.FindGameObjectsWithTag("GoblinHouse").Length;
        numMines = GameObject.FindGameObjectsWithTag("GoldMine").Length;
        numTowers = GameObject.FindGameObjectsWithTag("GoblinTower").Length;

        SelectObjective();
    }

    public void SelectObjective()
    {
        index = Random.Range(0, 2);
        if(index == 1)
        {
            //Get items objective
            SetItemsToCollect();
            objectiveType = ObjectiveType.CollectItems;
        }
        else
        {
            //Destroy buildings objective
            SetBuildingsToDestroy();
            objectiveType = ObjectiveType.DestroyBuildings;
        }
    }

    void SetItemsToCollect()
    {
        objectiveTitle.text = "Get the following items";
        numWood = numMeat = numGold = 0;

        for(int i = 0; i < iterations && price > 0; i++)
        {
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                if(price - woodCost > 0)
                {
                    price -= woodCost;
                    numWood++;
                }
            }
            else if(random == 1)
            {
                if(price - meatCost > 0)
                {
                    price -= meatCost;
                    numMeat++;
                }
            }
            else if(random == 2)
            {
                if(price - goldCost > 0)
                {
                    price -= goldCost;
                    numGold++;
                }
            }

            if(price <= 0)
            {
                break;
            }
        }

        if(numWood > 0)
        {
            GameObject objGO = Instantiate(objectiveGOItem, placeToSpawnObjective);
            objGO.GetComponent<ObjectiveGO>().SetItem(woodSprite, numWood);

            woodGO = objGO;
        }

        if(numMeat > 0)
        {
            GameObject objGO = Instantiate(objectiveGOItem, placeToSpawnObjective);
            objGO.GetComponent<ObjectiveGO>().SetItem(meatSprite, numMeat);

            meatGO = objGO;
        }

        if(numGold > 0)
        {
            GameObject objGO = Instantiate(objectiveGOItem, placeToSpawnObjective);
            objGO.GetComponent<ObjectiveGO>().SetItem(goldSprite, numGold);

            goldGO = objGO;
        }
    }

    void SetBuildingsToDestroy()
    {
        objectiveTitle.text = "Destroy the following buildings";

        if(numHouses > 5) 
        {
            GameObject objGO = Instantiate(objectiveGOBuilding, placeToSpawnObjective);
            numHousesToDestroy = Random.Range(4, numHouses);
            objGO.GetComponent<ObjectiveGO>().SetItem(houseSprite, numHousesToDestroy);

            houseGO = objGO;
        }
        else if(numHouses > 1)
        {
            GameObject objGO = Instantiate(objectiveGOBuilding, placeToSpawnObjective);
            numHousesToDestroy = Random.Range(1, numHouses);
            objGO.GetComponent<ObjectiveGO>().SetItem(houseSprite, numHousesToDestroy);

            houseGO = objGO;
        }

        if(numMines > 3) 
        {
            GameObject objGO = Instantiate(objectiveGOBuilding, placeToSpawnObjective);
            numMinesToDestroy = Random.Range(1, numMines);
            objGO.GetComponent<ObjectiveGO>().SetItem(mineSprite, numMinesToDestroy);

            mineGO = objGO;
        }

        if(numTowers > 5) 
        {
            GameObject objGO = Instantiate(objectiveGOBuilding, placeToSpawnObjective);
            numTowersToDestroy = Random.Range(4, numTowers);
            objGO.GetComponent<ObjectiveGO>().SetItem(towerSprite, numTowersToDestroy);

            towerGO = objGO;
        }
        else if(numTowers > 1) 
        {
            GameObject objGO = Instantiate(objectiveGOBuilding, placeToSpawnObjective);
            numTowersToDestroy = Random.Range(1, numTowers);
            objGO.GetComponent<ObjectiveGO>().SetItem(towerSprite, numTowersToDestroy);

            towerGO = objGO;
        }
    }

    public void CollectItem(string name)
    {
        if(name == "Wood")
        {
            numWood--;
            woodGO.GetComponent<ObjectiveGO>().SetItem(numWood);
            CheckIfObjectiveCompleted();
        }
        else if(name == "Meat")
        {
            numMeat--;
            meatGO.GetComponent<ObjectiveGO>().SetItem(numMeat);
            CheckIfObjectiveCompleted();
        }
        else if(name == "Gold")
        {
            numGold--;
            goldGO.GetComponent<ObjectiveGO>().SetItem(numGold);
            CheckIfObjectiveCompleted();
        }
    }

    public void DestroyBuilding(string name)
    {
        if(name == "GoblinHouse")
        {
            numHousesToDestroy--;
            houseGO.GetComponent<ObjectiveGO>().SetItem(numHousesToDestroy);
            CheckIfObjectiveCompleted();
        }
        else if(name == "GoldMine")
        {
            numMinesToDestroy--;
            mineGO.GetComponent<ObjectiveGO>().SetItem(numMinesToDestroy);
            CheckIfObjectiveCompleted();
        }
        else if(name == "GoblinTower")
        {
            numTowersToDestroy--;
            towerGO.GetComponent<ObjectiveGO>().SetItem(numTowersToDestroy);
            CheckIfObjectiveCompleted();
        }
    }

    void CheckIfObjectiveCompleted()
    {
        if(objectiveType == ObjectiveType.DestroyBuildings)
        {
            if(numHousesToDestroy <= 0 && numMinesToDestroy <= 0 && numTowersToDestroy <= 0) 
            {
                Debug.Log("Objective Completed");
                SceneManager.LoadScene("MainScene");
            }
        }
        else
        {
            if(numWood <= 0 && numMeat <= 0 && numGold <= 0) 
            {
                Debug.Log("Objective Completed");
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
