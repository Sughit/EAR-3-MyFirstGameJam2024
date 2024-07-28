using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalLight : MonoBehaviour
{
    public void ChangeScene()
    {
        if(SceneManager.GetActiveScene().name == "MainScene") SceneManager.LoadScene("Forest");
        if(SceneManager.GetActiveScene().name == "Forest") SceneManager.LoadScene("MainScene");
    }
}
