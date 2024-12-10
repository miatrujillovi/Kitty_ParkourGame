using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    //Public Variables
    public float newCameraDistance, speed, rotationSpeed;
    public CameraController cameraController;
    public CinemachineVirtualCamera virtualCamera;

    //Private Variables
    private Cinemachine3rdPersonFollow thirdPersonComponent;

    //When entering the state
    public override void OnEnter(PlayerStateMachine _machine)
    {
        //Stop camera movement/control
        cameraController.CanRotate(false);

        //Get third person reference (component)
        thirdPersonComponent = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

        //Deactive movement and character controller (We access the player through the _machine)
        _machine.gameObject.GetComponent<PlayerMovement>().enabled = false;
        _machine.gameObject.GetComponent<CharacterController>().enabled = false;

        //We add a rigidbody to the player
        _machine.gameObject.AddComponent<Rigidbody>();

        //We add a torque to the rigidbody to make it have a rotational force
        _machine.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(50f, 0f, 0f));
    }

    //When exiting the state
    public override void OnExit(PlayerStateMachine _machine)
    {
        
    }

    //Updates the state every frame
    public override void OnUpdate(PlayerStateMachine _machine)
    {
        //We make the camera move while smoothing with Lerp
        thirdPersonComponent.CameraDistance = Mathf.Lerp(thirdPersonComponent.CameraDistance, newCameraDistance, speed * Time.deltaTime);

        //We rotate the cameraController in y
        cameraController.gameObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

}
