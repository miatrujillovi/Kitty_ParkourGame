using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    //Private Variables
    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        isClimbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Stops climbing if space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isClimbing = false;
        }
    }

    //Function when it triggers the collider with a tag "Stair"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stair"))
        {
            isClimbing = true;
        }
    }

    //Function when it exits the collider with a tag "Stair"
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stair"))
        {
            isClimbing = false;
        }
    }

    //Function that returns the state of isClimbing
    public bool IsClimbing()
    {
        return isClimbing;
    }
}
