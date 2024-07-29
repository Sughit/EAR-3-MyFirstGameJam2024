using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentruAnimatiiArcher : MonoBehaviour
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
}
