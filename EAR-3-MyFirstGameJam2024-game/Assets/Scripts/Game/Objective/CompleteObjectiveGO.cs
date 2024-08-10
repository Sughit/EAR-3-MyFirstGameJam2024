using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteObjectiveGO : MonoBehaviour
{
    string tag;

    void Awake()
    {
        tag = gameObject.tag;
    }

    void OnDestroy()
    {
        if(MeniuInGame.loadingMainMenu) return;
        if(ObjectiveManager.instance.objectiveCompleted) return;
        Debug.Log("Destroyed " + gameObject.name);

        if(ObjectiveManager.instance.objectiveType == ObjectiveManager.ObjectiveType.DestroyBuildings)
        {
            ObjectiveManager.instance.DestroyBuilding(tag);
        }
        else if(ObjectiveManager.instance.objectiveType == ObjectiveManager.ObjectiveType.CollectItems)
        {
            ObjectiveManager.instance.CollectItem(tag);
        }
    }
}
