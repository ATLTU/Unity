using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private bool _isInRange;
    [SerializeField]
    private KeyCode _interactKey;
    [SerializeField]
    private UnityEvent _interactionEvent;

    // Update is called once per frame
    void Update()
    {
        // If Player is in range of the object
        if(_isInRange)
		{
            // And pressed the selected key for interaction
            if(Input.GetKeyDown(_interactKey)) 
			{
                // Fire event
                _interactionEvent.Invoke(); 
			}
		}   
    }

    void OnTriggerEnter2D(Collider2D collider)
	{
        // Checks if Player has entered the range of the collider
        if(collider.gameObject.CompareTag("Player"))
		{
            _isInRange = true;
            collider.gameObject.GetComponent<PlayerManager>().NotifyPlayer();
            //Debug.Log("Player is in range");
		}
	}

    void OnTriggerExit2D(Collider2D collider)
	{
        // Checks if Player has exit the range of the collider
        if (collider.gameObject.CompareTag("Player"))
        {
            _isInRange = false;
            collider.gameObject.GetComponent<PlayerManager>().DenotifyPlayer();
            //Debug.Log("Player is not in range");
        }
    }
}
