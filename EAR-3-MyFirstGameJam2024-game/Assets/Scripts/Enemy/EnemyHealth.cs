using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float maxHealth = 100f;
    [SerializeField] private float health;
    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
            Destroy(gameObject);
    }
}
