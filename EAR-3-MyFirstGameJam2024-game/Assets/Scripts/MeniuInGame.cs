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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!menuCheck)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                menu.SetActive(true);
                Time.timeScale = 0;
                menuCheck = true;
            }
            else
                Resume();
        }
    }
}
