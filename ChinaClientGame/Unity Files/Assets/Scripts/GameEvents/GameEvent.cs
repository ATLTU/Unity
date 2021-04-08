using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public event Action<PlayerStateType> playerState;
    public static GameEvent current;
    private void Awake()
    {
        current = this;
    }

    public void CallPlayerState(PlayerStateType playerStateType)
    {
        if(playerState != null)
        {
            playerState.Invoke(playerStateType);
        }
    }
}
