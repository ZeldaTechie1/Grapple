using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class InputProcessor
{
    PlayerInput _playerInput;
    InputAction _movementAction;
    Camera _playerCamera;

    public void Initialize(PlayerInput playerInput, Camera playerCamera)
    {
        _playerCamera = playerCamera;

        _playerInput = playerInput;
        _movementAction = _playerInput.actions["Move"];

    }

    public void ProcessInput()
    {
        Vector2 rawInput = _movementAction.ReadValue<Vector2>();
        //TODO: process input based on the camera and the slope that the character is standing on
    }
}
