using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentruAnimatii : MonoBehaviour
{
    List <Collider2D> colliders = new List<Collider2D>();
    public bool isAttacking = false, isDead = false;
    private bool cut = false;
    [SerializeField] private float damage = 10;
    [SerializeField] private GameObject sunetBreak;

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
    public void inDying()
    {
        isDead = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy" && cut && verificare(col))
        {
            colliders.Add(col);
            col.TryGetComponent<EnemyHealth>(out EnemyHealth enemy);
            enemy.TakeDamage(damage);
            Debug.Log("hit");
        }
        ForestBuildings forest = col.GetComponent<ForestBuildings>();

        if(forest != null && cut && verificare(col))
        {
            Instantiate(sunetBreak);
            colliders.Add(col);
            forest.Damage();
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
