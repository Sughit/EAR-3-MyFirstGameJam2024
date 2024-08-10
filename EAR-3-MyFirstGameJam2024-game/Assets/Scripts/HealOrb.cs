using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOrb : MonoBehaviour
{
    [SerializeField] private float healAmmount;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.TryGetComponent<PlayerHealth>(out var health);
            if(health != null) health.TakeDamage(-healAmmount);

            Destroy(this.gameObject);
        }
    }
}
