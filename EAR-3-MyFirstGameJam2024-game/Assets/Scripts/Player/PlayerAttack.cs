using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAttack : MonoBehaviour
{
    private string dir;
    Animator anim;
    [SerializeField]private CinemachineVirtualCamera cam;
    [SerializeField]private Transform right, up, left, down;
    [SerializeField] private PentruAnimatii animScript;
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        dir = GetComponent<Movement>().direction;
        if(Input.GetKeyDown(KeyCode.Mouse0) && !animScript.isAttacking && !animScript.isDead)
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
        switch(dir)
        {
            case "right":
                cam.LookAt = right;
            break;
            case "left":
                cam.LookAt = left;
            break;
            case "up":
                cam.LookAt = up;
            break;
            case "down":
                cam.LookAt = down;
            break;
        }
    }
}
