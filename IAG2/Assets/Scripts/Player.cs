using KinematicCharacterController;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, ICharacterController
{

    [SerializeField]StateMachine _playerStateMachine;
    [SerializeField]KinematicCharacterMotor _characterMotor;
    [SerializeField]Camera _playerCamera;
    [SerializeField]PlayerInput _playerInput;
    [SerializeField]InputProcessor _inputProcessor;

    private void Awake()
    {
        if (!_playerStateMachine)
            _playerStateMachine = GetComponent<StateMachine>();

        _characterMotor.CharacterController = this;
        _inputProcessor.Initialize(_playerInput, _playerCamera);
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        _inputProcessor.ProcessInput();
        _playerStateMachine.CurrentState.BeforeCharacterUpdate(deltaTime);
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
        _playerStateMachine.CurrentState.AfterCharacterUpdate(deltaTime);
    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        return _playerStateMachine.CurrentState.IsColliderValidForCollisions(coll);
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        _playerStateMachine.CurrentState.OnDiscreteCollisionDetected(hitCollider);
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        _playerStateMachine.CurrentState.OnGroundHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        _playerStateMachine.CurrentState.OnMovementHit(hitCollider,hitNormal,hitPoint, ref hitStabilityReport);
    }

    public void PostGroundingUpdate(float deltaTime)
    {
        _playerStateMachine.CurrentState.PostGroundingUpdate(deltaTime);
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        _playerStateMachine.CurrentState.ProcessHitStabilityReport(hitCollider, hitNormal, hitPoint, atCharacterPosition, atCharacterRotation, ref hitStabilityReport);
    }

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        _playerStateMachine.CurrentState.UpdateRotation(ref currentRotation, deltaTime);
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        _playerStateMachine.CurrentState.UpdateVelocity(ref currentVelocity, deltaTime);
    }
}
