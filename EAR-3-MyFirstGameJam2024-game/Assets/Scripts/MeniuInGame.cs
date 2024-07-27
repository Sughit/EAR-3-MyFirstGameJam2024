using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuInGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool menuCheck;

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    } 
    public void Resume()
    {
        menu.SetActive(false);
        menuCheck = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!menuCheck)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                menuCheck = true;
            }
            else
                Resume();
        }
    }
}
