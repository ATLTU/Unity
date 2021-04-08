using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PauseMenuScript pauseMenuScript;

    void OnCollisionEnter(Collision collisionInfo)
    {
        //UnityEngine.Debug.Log(collisionInfo.collider.name);
        pauseMenuScript.Pause();
    }
}
