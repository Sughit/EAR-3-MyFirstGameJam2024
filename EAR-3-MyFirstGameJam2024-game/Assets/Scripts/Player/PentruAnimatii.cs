using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentruAnimatii : MonoBehaviour
{
    public bool isAttacking = false;

    public void isAttackingStart()
    {
        isAttacking = true;
    }
    public void isAttackingStop()
    {
        isAttacking = false;
    }
}
