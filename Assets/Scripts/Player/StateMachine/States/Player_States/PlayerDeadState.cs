using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public PlayerMoveState moveState;

    //When entering the state
    public override void OnEnter(PlayerStateMachine _machine)
    {
        StartCoroutine(RestartMovement(_machine));
    }

    //When exiting the state
    public override void OnExit(PlayerStateMachine _machine)
    {
        
    }

    //Updates the state every frame
    public override void OnUpdate(PlayerStateMachine _machine)
    {

    }

    IEnumerator RestartMovement(PlayerStateMachine _machine)
    {
        yield return new WaitForSeconds(1f);
        _machine.SwitchState(moveState);
    }
}
