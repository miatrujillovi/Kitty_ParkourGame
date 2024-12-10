using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    //Public Variables
    public PlayerMoveState moveState;
    public PlayerClimbState climbState;
    public PlayerDeadState deadState;

    //Private Variables
    private PlayerBaseState currentState;

    // Start is called before the first frame update
    void Start()
    {
        //Initialization of States
        currentState = moveState;
        currentState.OnEnter(this); //this is because is asking for the machine (_machine), same with the other functions
    }

    // Update is called once per frame
    void Update()
    {
        //Check if we have a state
        if (currentState != null)
        {
            //Update the state
            currentState.OnUpdate(this);
        }
    }

    //Function to Swich the State (it receives the new state)
    public void SwitchState(PlayerBaseState _state)
    {
        //We exit the state were currently in
        currentState.OnExit(this);

        //We change the state
        currentState = _state;
        currentState.OnEnter(this);
    }

    //Function to administrate more easily Death state/function
    public void Death()
    {
        SwitchState(deadState);
    }
}
