using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentruAnimatii : MonoBehaviour
{
    List <Collider2D> colliders = new List<Collider2D>();
    public bool isAttacking = false;
    private bool cut = false;
    [SerializeField] private float damage = 10;

    public void isAttackingStart()
    {
        isAttacking = true;
    }
    public void isAttackingStop()
    {
        isAttacking = false;
    }
    public void inDamageStart()
    {
        cut = true;
    }
    public void inDamageStop()
    {
        cut = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy" && cut && verificare(col))
        {
            colliders.Add(col);
            col.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log("hit");
        }
    }
    bool verificare(Collider2D col)
    {
        foreach(Collider2D nume in colliders)
            if(col == nume)
                return false;
        return true;
    }
    void Update()
    {
        if(!isAttacking)
            colliders = new List<Collider2D>();
    }
}
