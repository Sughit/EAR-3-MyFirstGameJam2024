using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAttackArcher : MonoBehaviour
{
    private string dir;
    Animator anim;
    [SerializeField]private CinemachineVirtualCamera cam;
    [SerializeField] private PentruAnimatiiArcher animScript;
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        Cursor.visible = true;
        dir = GetComponent<MovementArcher>().direction;
        if(Input.GetKeyDown(KeyCode.Mouse0) && !animScript.isAttacking)
            switch(dir)
            {
                case "right":
                    anim.SetTrigger("attackRight");
                break;
                case "left":
                    anim.SetTrigger("attackRight");
                break;
                case "up":
                    anim.SetTrigger("attackUp");
                break;
                case "down":
                    anim.SetTrigger("attackDown");
                break;
                
            }
    }
}
