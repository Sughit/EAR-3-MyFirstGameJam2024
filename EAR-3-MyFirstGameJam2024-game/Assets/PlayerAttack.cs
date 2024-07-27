using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private string dir;
    Animator anim;
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>(); 
    }

    
    void Update()
    {
        dir = GetComponent<Movement>().direction;
        if(Input.GetKeyDown(KeyCode.Mouse0))
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
