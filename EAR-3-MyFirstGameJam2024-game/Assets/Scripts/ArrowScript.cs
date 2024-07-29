using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    bool canMove = true;
    [SerializeField] private float speed = 5;
    [SerializeField] private float damage = 10;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Player" && other.tag != "MapWalls")
        {
            canMove = false;
            transform.SetParent(other.transform);   
            other.TryGetComponent<EnemyHealth>(out EnemyHealth enemy);
            if(enemy != null) enemy.TakeDamage(damage);
        }     
    }

    void Update()
    {
        if(canMove)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }
}
