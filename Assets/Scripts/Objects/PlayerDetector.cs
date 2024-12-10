using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    //Public Variables
    public UnityEvent onPlayerDetected;

    //Function to detect the player
    private void OnTriggerEnter(Collider other)
    {
        //If it detects the "Player"
        if (other.CompareTag("Player"))
        {
            //It calls a Unity Event
            onPlayerDetected.Invoke();
        }
    }
}
