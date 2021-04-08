using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerStateType playerState;
    [SerializeField]
    private BoxSentenceMatchCombinations SentenceBool;
    private RayDetection rayDetection;
    [SerializeField] private int health = 100;
    [SerializeField] private int attack = 10;

    public GameOverScript gameOver;

    private void Awake()
    {
        rayDetection = GetComponent<RayDetection>();
        gameOver = FindObjectOfType<GameOverScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.playerState += SetMyPlayerState;
    }

    // Update is called once per frame
    void Update()
    {
        RayCheck();

        if(IsPlayerDead(health) == true)
        {
            gameOver.GameOver();
        }
    }

    private void RayCheck()
    {
        GameObject LeftGameObject = rayDetection.RayHitGameObjectLeft;
        GameObject RightGameObject = rayDetection.RayHitGameObjectRight;
        GameObject UpGameObject = rayDetection.RayHitGameObjectUp;

        if (LeftGameObject != null)
        {
            if (LeftGameObject.tag == "Door")
            {
                if(LeftGameObject.GetComponent<DoorMechanic>().DoorUnlocked == true)
                {
                    LeftGameObject.GetComponent<DoorMechanic>().UnlockDoor();
                }
            }   
        }
        if(RightGameObject != null)
        {
            if (RightGameObject.tag == "Door")
            {
                if (RightGameObject.GetComponent<DoorMechanic>().DoorUnlocked == true)
                {
                    RightGameObject.GetComponent<DoorMechanic>().UnlockDoor();
                }
            }
        }
        if (UpGameObject != null)
        {
            if (UpGameObject.tag == "Door")
            {
                if (UpGameObject.GetComponent<DoorMechanic>().DoorUnlocked == true)
                {
                    UpGameObject.GetComponent<DoorMechanic>().UnlockDoor();
                }
            }
        }
    }

    private void SetMyPlayerState(PlayerStateType _playerState)
    {
        playerState = _playerState;
    }

    public void TakeDamage(int EnemyDamage)
    {
        health -= EnemyDamage;
        IsPlayerDead(health);
    }

    public bool IsPlayerDead(int Health)
    {
        if(Health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerStateType typesafe = playerState;
            if(playerState == PlayerStateType.DoorAttackMe || playerState == PlayerStateType.MeAttackDoor)
            {
                playerState = PlayerStateType.EnemeyAttackMe;
            }

            if (playerState == PlayerStateType.EnemeyAttackMe)
            {
                TakeDamage(collision.gameObject.GetComponent<EnemyChasePlayer>().Attack);
            }

            if (playerState == PlayerStateType.MeAttackEnemey)
            {
                collision.gameObject.GetComponent<EnemyChasePlayer>().TakeDamage(attack);
            }
            playerState = typesafe;
        }
        
        if(collision.gameObject.tag == "Door")
        {
            if(playerState == PlayerStateType.DoorAttackMe)
            {
                TakeDamage(collision.gameObject.GetComponent<DoorMechanic>().DoorDamage);
            }
        }

        if(collision.gameObject.tag == "WinGame")
        {
            FindObjectOfType<GameOverScript>().Win();
        }

        if(collision.gameObject.tag == "Crate")
        {
            collision.gameObject.GetComponent<CrateRemoval>().Disable(playerState);
        }
    }
}
