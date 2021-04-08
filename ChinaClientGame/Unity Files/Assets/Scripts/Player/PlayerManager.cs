using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject interactNotify;

    void Start()
	{
        DenotifyPlayer();
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void NotifyPlayer()
	{
        interactNotify.SetActive(true);
	}

    public void DenotifyPlayer()
	{
        interactNotify.SetActive(false);
	}
}
