using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPawn : MonoBehaviour
{
    bool canSeeTutorial = false;
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private GameObject tutorialText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canSeeTutorial = true;
            tutorialText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canSeeTutorial = false;
            tutorialText.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(canSeeTutorial)
            {
                tutorialWindow.SetActive(true);
                tutorialText.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
