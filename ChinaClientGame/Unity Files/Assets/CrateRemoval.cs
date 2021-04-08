using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateRemoval : MonoBehaviour
{
    public void Disable(PlayerStateType playerState)
    {
        if (playerState == PlayerStateType.MeAttackEnemey)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
