using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private GameObject sunetPickUp;
    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(sunetPickUp);
        if(other.tag == "Player") Destroy(this.gameObject);
    }    
}
