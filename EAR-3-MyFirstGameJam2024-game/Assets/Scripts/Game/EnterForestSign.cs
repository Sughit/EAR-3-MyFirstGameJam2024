using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterForestSign : MonoBehaviour
{
    bool canEnter;

    [SerializeField] private ExitType exitFrom;
    [SerializeField] private GameObject canvas;

    public enum ExitType
    {
        Forest,
        Town,
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canEnter = true;
            canvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canEnter = false;
            canvas.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canEnter)
        {
            canvas.SetActive(false);
            GetComponent<CircleCollider2D>().enabled = false;

            if(exitFrom == ExitType.Town) GameManager.instance.EnterForest();
            if(exitFrom == ExitType.Forest) GameManager.instance.ExitForest();
        }
    }
}
