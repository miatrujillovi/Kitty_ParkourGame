using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointManager checkpointManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && checkpointManager != null)
        {
            checkpointManager.SetCurrentCheckpoint(gameObject);
        }
    }
}
