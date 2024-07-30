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
    [SerializeField] private MovementArcher movem;
    [SerializeField] private GameObject directionPoint;
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log(directionPoint.transform.rotation.z);
        Cursor.visible = true;
        dir = GetComponent<MovementArcher>().direction;
        if(Input.GetKeyDown(KeyCode.Mouse0) && !animScript.isAttacking && !movem.isDashing)
            if(directionPoint.transform.rotation.z > -0.125f && directionPoint.transform.rotation.z <= 0.125f)
                anim.SetTrigger("attackRight");
            else if(directionPoint.transform.rotation.z > 0.125f && directionPoint.transform.rotation.z <= 0.6f)
                anim.SetTrigger("rightUp");
            else if(directionPoint.transform.rotation.z > 0.6f && directionPoint.transform.rotation.z <= 0.8f)
                anim.SetTrigger("attackUp");
            else if(directionPoint.transform.rotation.z > 0.8f && directionPoint.transform.rotation.z <= 0.99f)
                anim.SetTrigger("rightUp");
            else if(directionPoint.transform.rotation.z > 0.99f || directionPoint.transform.rotation.z <= -0.975f)
                anim.SetTrigger("attackRight");
            else if(directionPoint.transform.rotation.z > -0.975f && directionPoint.transform.rotation.z <= -0.80f)
                anim.SetTrigger("rightDown");
            else if(directionPoint.transform.rotation.z > -0.80f && directionPoint.transform.rotation.z <= -0.6f)
                anim.SetTrigger("attackDown");
            else if(directionPoint.transform.rotation.z > -0.6f && directionPoint.transform.rotation.z <= -0.125f)
                anim.SetTrigger("rightDown");
            
            
    }
}
