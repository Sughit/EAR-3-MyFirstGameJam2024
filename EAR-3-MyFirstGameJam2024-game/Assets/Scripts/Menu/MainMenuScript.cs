using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject main, settings, butonSettings, butonPlay, butonQuit, sunet;
    void Awake()
    {
        butonSettings.SetActive(false);
        butonPlay.SetActive(false);
        butonQuit.SetActive(false);

        StartCoroutine(Butoane());
    }
    public void PlayGame()
    {
        StartCoroutine(Butoane2());

        if(SelectCharacter.instance != null) SelectCharacter.instance.canSelect = true;
    }
    public void Settings()
    {
        settings.SetActive(true);
        main.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackSettings()
    {
        settings.SetActive(false);
        main.SetActive(true);
    }
    public void Sunet()
    {
        Instantiate(sunet);
    }
    IEnumerator Butoane()
    {
        yield return new WaitForSeconds(0.08f);
        butonQuit.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        butonSettings.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        butonPlay.SetActive(true);
    }
    IEnumerator Butoane2()
    {
        butonQuit.SetActive(false);
        yield return new WaitForSeconds(0.08f);
        butonSettings.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("MainScene");
    }
}