using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ControllsUi;
    public GameObject mainMenuUi;

    public void Awake()
    {
        FindObjectOfType<AudioManager>().Play("MainMenu");
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); 
    }

    public void Controlls()
    {
        ControllsUi.SetActive(true);
        mainMenuUi.SetActive(false);
    }

    public void ReturnMainMenu()
    {
        ControllsUi.SetActive(false);
        mainMenuUi.SetActive(true);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
