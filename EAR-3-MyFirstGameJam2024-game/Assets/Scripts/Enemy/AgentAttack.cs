using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttack : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        AttackSide();
    }

    void AttackSide()
    {
        anim.SetTrigger("attackRight");
    }
}
