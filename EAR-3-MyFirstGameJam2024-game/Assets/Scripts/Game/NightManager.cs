using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class NightManager : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Start()
    {
        GameManager.instance.OnForestEnter += EnterForest;
        GameManager.instance.OnForestExit += ExitForest;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        anim = GameObject.FindWithTag("Global Light").GetComponent<Animator>();
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
