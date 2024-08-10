using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAttack : AgentAttack
{
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float time = 3f;
    [SerializeField] private GameObject sunetExplode;

    void Awake()
    {
        Invoke("Attack", time);
        anim = GetComponent<Animator>();
    }
    public override void Attack()
    {
        anim.SetTrigger("attack");    
    }

    public void Damage()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, range, layerMask);
        foreach(Collider2D collider in col)
        {
            collider.gameObject.TryGetComponent<PlayerHealth>(out var health);
            health.TakeDamage(damage);
        }
    }
    public void Explozie()
    {
        Instantiate(sunetExplode);
    }

    public void DestroyGO()
    {
        Destroy(transform.parent.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
