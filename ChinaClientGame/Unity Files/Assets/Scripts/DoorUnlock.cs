using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> doorsUnlocked = new List<GameObject>();
    public bool doorsUnlockedComplete = false;

    private PlayerBehaviour playerstate;

    private void Start()
    {
        playerstate = FindObjectOfType<PlayerBehaviour>();
    }
    private void Update()
    {
        if(playerstate.playerState == PlayerStateType.MeAttackDoor && doorsUnlockedComplete == false)
        {
            SentenceUnlockDoors();
        }
    }
    public void SentenceUnlockDoors()
    {
        foreach (GameObject item in doorsUnlocked)
        {
            item.GetComponent<DoorMechanic>().DoorUnlocked = true;
        }
        doorsUnlockedComplete = true;
    }
}
