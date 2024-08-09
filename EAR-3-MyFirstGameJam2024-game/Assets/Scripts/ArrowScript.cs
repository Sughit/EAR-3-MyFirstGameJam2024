using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    bool canMove = true;
    [SerializeField] private float speed = 5;
    [SerializeField] private float damage = 10;
    [SerializeField] private GameObject sunetBreak;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 6f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Player" && other.tag != "MapWalls")
        {
            canMove = false;
            transform.SetParent(other.transform);   
            other.TryGetComponent<EnemyHealth>(out EnemyHealth enemy);
            if(enemy != null) enemy.TakeDamage(damage);

            other.TryGetComponent<ForestBuildings>(out ForestBuildings forest);
            if(forest != null)
            {
                forest.Damage();
                Instantiate(sunetBreak);
            } 

            Destroy(gameObject);
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
