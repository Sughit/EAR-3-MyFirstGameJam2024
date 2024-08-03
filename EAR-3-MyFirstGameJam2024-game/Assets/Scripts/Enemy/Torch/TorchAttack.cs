using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAttack : AgentAttack
{
    public override void Attack()
    {
        AttackSide();
    }

    void AttackSide()
    {
        anim.SetTrigger("attackRight");
    }
}
