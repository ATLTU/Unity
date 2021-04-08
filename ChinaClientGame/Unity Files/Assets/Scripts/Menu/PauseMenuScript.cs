using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
//=============================================================================
    // Update is called once per frame
    private void Update()
    {
    	//Escape button, triggers the screen
		if (Input.GetKeyDown(KeyCode.Escape))
		{  
			//If escape is pressed. Game is paused
			if (GameIsPaused)
			{
				//Calls the resume part
				Resume();

                //Calls the restart part
                Restart();
            }
            else
			{
				//Calls the pause part
				Pause();
			}
		}        
    }
//=============================================================================
    public void Resume()
    {
    	//Pause Menu UI is deactivated
    	pauseMenuUI.SetActive(false);
    	//Normal game time
    	Time.timeScale = 1f;
    	//Normal game time = game is not paused
    	GameIsPaused = false;
    }
//=============================================================================
    public void Pause()
    {
    	//Activates pause menu UI
    	pauseMenuUI.SetActive(true);
    	//Paused game time
    	Time.timeScale = 0f;
    	//Paused game time = game is paused
    	GameIsPaused = true;
    }
    //=============================================================================
    public void Restart()
    {
        //Restarts Current Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameIsPaused = false;
    }
    //=============================================================================
    public void QuitGame()
    {
    	//Debug stuff
    	Debug.Log("Quiting Game...");
    	//Quits the application
    	Application.Quit();
    }
}
