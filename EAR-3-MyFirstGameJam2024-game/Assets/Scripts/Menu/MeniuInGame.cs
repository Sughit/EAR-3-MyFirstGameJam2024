using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuInGame : MonoBehaviour
{
    [SerializeField] private GameObject menu, sunet;
    public bool menuCheck;
    public static bool loadingMainMenu;

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        loadingMainMenu = true;
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
        Cursor.visible = false;
    }
    public void Sunet()
    {
        Instantiate(sunet);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!menuCheck)
            {
                Cursor.lockState = CursorLockMode.Confined;
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
