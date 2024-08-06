using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBuildings : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private LayerMask layerMask;
    private Collider2D[] trees;
    Animator anim;
    private int hits = 0;
    void Awake()
    {
        anim = GetComponent<Animator>();
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
    public void Damage()
    {
        hits++;
        anim.SetTrigger("takeDamage");
        if(hits == 5)
        Destroy(gameObject);
    }
}
