using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject gameOverMenuUI;

    public GameObject winMenuUI;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverMenuUI.SetActive(false);
        winMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gameOverMenuUI.SetActive(false);
        winMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = false;
    }

    public void GameOver()
    {
        //Activates pause menu UI
        gameOverMenuUI.SetActive(true);
        //Paused game time
        Time.timeScale = 0f;
        //Paused game time = game is paused
        GameIsOver = true;
    }

    public void Win()
    {
        //Activates pause menu UI
        winMenuUI.SetActive(true);
        //Paused game time
        Time.timeScale = 0f;
        //Paused game time = game is paused
        GameIsOver = true;
    }

    public void QuitGame()
    {
        //Debug stuff
        Debug.Log("Quiting Game...");
        //Quits the application
        Application.Quit();
    }
}
