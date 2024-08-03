using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttack : MonoBehaviour
{
    [HideInInspector] public  Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public virtual void Attack()
    {
        
    }
}
