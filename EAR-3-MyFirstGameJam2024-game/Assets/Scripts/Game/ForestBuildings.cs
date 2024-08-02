using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBuildings : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private LayerMask layerMask;
    private Collider2D[] trees;
    void Awake()
    {
        trees = Physics2D.OverlapCircleAll(transform.position, range, layerMask);
        foreach(Collider2D tree in trees)
        {
            Destroy(tree.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
