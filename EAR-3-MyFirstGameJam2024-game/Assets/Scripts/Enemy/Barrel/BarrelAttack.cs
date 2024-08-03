using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAttack : AgentAttack
{
    public override void Attack()
    {
        anim.SetTrigger("attack");
    }

    public void DamageAndDestroy()
    {
        //damage the area
        Destroy(transform.parent.gameObject);
    }
}
