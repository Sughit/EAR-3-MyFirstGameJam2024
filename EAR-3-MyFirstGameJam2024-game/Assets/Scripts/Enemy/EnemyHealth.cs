using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] private float health;
    [SerializeField] private int numDrops;
    [SerializeField] private GameObject[] drops;
    [SerializeField] private float range;
    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        anim.SetTrigger("takeDamage");
        if(health <= 0)
        {
            for(int i = 0; i < drops.Length; i++)
            {
                Instantiate(drops[Random.Range(0, drops.Length)], new Vector2(transform.position.x, transform.position.y) + Random.insideUnitCircle * range, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
