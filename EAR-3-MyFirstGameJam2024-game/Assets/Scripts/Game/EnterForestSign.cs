using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterForestSign : MonoBehaviour
{
    bool canEnter;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canEnter = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canEnter)
        {
            GameManager.instance.EnterForest();
        }
    }
}
