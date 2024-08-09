using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAttack : AgentAttack
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damage;
    public override void Attack()
    {
        AttackSide();
    }

    void AttackSide()
    {
        anim.SetTrigger("attackRight");
    }

    public void Damge()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position + offset, range, layerMask);
        foreach(Collider2D collider in col)
        {
            collider.gameObject.TryGetComponent<PlayerHealth>(out var health);
            health.TakeDamage(damage);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, range);
    }
}
