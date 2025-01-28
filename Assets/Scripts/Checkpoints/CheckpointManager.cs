using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject player;

    public GameObject currentCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentCheckpoint(GameObject _checkpoint)
    {
        currentCheckpoint = _checkpoint;
    }

    public void MovePlayer()
    {
        if (currentCheckpoint != null)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.transform.position = currentCheckpoint.transform.position;
            player.GetComponent<PlayerMovement>().enabled = true;
            Debug.Log("Movi JIJI");
        }
    }
}
