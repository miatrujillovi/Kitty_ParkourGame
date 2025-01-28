using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogTrigger : MonoBehaviour
{
    public FogManager fogManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && fogManager != null)
        {
            fogManager.SetFogState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && fogManager != null)
        {
            fogManager.SetFogState(false);
        }
    }
}
