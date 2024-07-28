using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NightManager : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Start()
    {
        GameManager.instance.OnForestEnter += EnterForest;
        GameManager.instance.OnForestExit += ExitForest;
    }

    void EnterForest(object sender, EventArgs e)
    {
        Debug.Log("Getting dark");

        anim.SetTrigger("exit");
    }
 
    void ExitForest(object sender, EventArgs e)
    {
        Debug.Log("Getting light");

        anim.SetTrigger("exit");
    }
}
