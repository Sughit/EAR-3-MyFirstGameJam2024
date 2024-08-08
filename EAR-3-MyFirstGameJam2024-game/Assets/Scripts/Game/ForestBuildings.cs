using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestBuildings : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private LayerMask layerMask;
    private Collider2D[] trees;
    [SerializeField] private GameObject[] drops;
    [SerializeField] private int numDrops;
    [SerializeField] private float dropRange;
    [SerializeField] private Sprite[] damageSprites;
    int index;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private int hits = 0;
    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, dropRange);
    }
    public void Damage()
    {
        hits++;
        anim.SetTrigger("takeDamage");

        if(hits == 2)
        {
            spriteRenderer.sprite = damageSprites[index];
            index++;
        }
        else if(hits == 4 && damageSprites.Length > 1)
        {
            spriteRenderer.sprite = damageSprites[index];
            index++;
        }
        else if(hits == 5)
        {
            if(ObjectiveManager.instance.objectiveType == ObjectiveManager.ObjectiveType.DestroyBuildings)
            {
                for(int i = 0; i < numDrops; i++)
                {
                    Instantiate(drops[Random.Range(0, drops.Length)], new Vector2(transform.position.x, transform.position.y) + Random.insideUnitCircle * dropRange, Quaternion.identity);
                }
            }
            Destroy(gameObject);
        }
    }
}
