using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> forests = new List<GameObject>();
    [SerializeField] private List<BuildingSpawnPoints> buildingSpawnPoints = new List<BuildingSpawnPoints>();
    [SerializeField] private BuildingInfo[] buildings;
    int index;

    void Start()
    {
        index = Random.Range(0, forests.Count);

        forests[index].SetActive(true);
        SpawnBuildings();
    }

    void SpawnBuildings()
    {
        BuildingSpawnPoints temp = buildingSpawnPoints[index];
        BuildingInfo[] tempBuildings = buildings;

        for(int i = 0; i < temp.pos.Count; i++)
        {
            if(Random.Range(0, 2) == 1)
            {
                int x = Random.Range(0, tempBuildings.Length);
                if(tempBuildings[x].maxNums > 0)
                {
                    Instantiate(tempBuildings[x].building, temp.pos[i], Quaternion.identity);
                    tempBuildings[x].maxNums--;
                }
            }
        }
    }

    [System.Serializable]
    public class BuildingSpawnPoints
    {
        public List<Vector3> pos = new List<Vector3>();
    }

    [System.Serializable]
    public class BuildingInfo
    {
        public GameObject building;
        public int maxNums;
    } 
}
