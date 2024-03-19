using KinematicCharacterController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class State : ICharacterController
{
    protected StateMachine _stateMachine;

    public static Action<State> StateEnteredEvent;
    public static Action<State> StateUpdatedEvent;
    public static Action<State> StateExitedEvent;

    public virtual void OnStateEnter(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public virtual void OnStateUpdate() { }
    public virtual void OnStateExit() { }

    public virtual void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        
    }

    public virtual void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        
    }

    public virtual void BeforeCharacterUpdate(float deltaTime)
    {
        
    }

    public virtual void PostGroundingUpdate(float deltaTime)
    {
        
    }

    public virtual void AfterCharacterUpdate(float deltaTime)
    {
        
    }

    public virtual bool IsColliderValidForCollisions(Collider coll)
    {
        return false;
    }

    public virtual void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        
    }

    public virtual void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        
    }

    public virtual void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        
    }

    public virtual void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        
    }
}
