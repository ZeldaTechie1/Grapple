using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : State
{
    PlayerInput _playerInput;
    public override void OnStateEnter(StateMachine stateMachine)
    {
        base.OnStateEnter(stateMachine);
        _playerInput = _stateMachine.GetComponent<PlayerInput>();
        if (!_playerInput)
            Debug.LogError($"Player input component is missing!");
    }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        
    }
    public override void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        
    }
}
