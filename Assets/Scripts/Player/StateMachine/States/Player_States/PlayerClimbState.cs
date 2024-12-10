using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerBaseState
{
    //Public Variables
    public PlayerMovement playerMovement;
    public Climber climbDetector;

    //When entering the state
    public override void OnEnter(PlayerStateMachine _machine)
    {
        
    }

    //When exiting the state
    public override void OnExit(PlayerStateMachine _machine)
    {
        
    }

    //Updates the state every frame
    public override void OnUpdate(PlayerStateMachine _machine)
    {
        playerMovement.Climb();

        //If climbdetector no longer detects a "stair"
        if (!climbDetector.IsClimbing())
        {
            //Change state to Move
            _machine.SwitchState(_machine.moveState);
        }
    }
}
