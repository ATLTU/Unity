using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void EndGame ()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            UnityEngine.Debug.Log("GAMEOVER");
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
