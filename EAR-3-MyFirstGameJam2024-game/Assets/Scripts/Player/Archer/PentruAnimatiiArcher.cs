using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentruAnimatiiArcher : MonoBehaviour
{
    List <Collider2D> colliders = new List<Collider2D>();
    public bool isAttacking = false, isDead = false;
    private bool cut = false;
    [SerializeField] private float damage = 10;
    private PlayerHealth health;

    void Awake()
    {
        health = transform.parent.gameObject.GetComponent<PlayerHealth>();
    }

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

    public void ShowDeathMenu()
    {
        health.ShowDeathMenu();
    }
}
