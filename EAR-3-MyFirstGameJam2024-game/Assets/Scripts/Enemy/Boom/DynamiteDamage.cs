using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteDamage : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask layerMask;
    public void DestroyGO()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Damage()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, range, layerMask);

        foreach (Collider2D collider in col)
        {
            collider.gameObject.TryGetComponent<PlayerHealth>(out var health);
            health.TakeDamage(damage);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
