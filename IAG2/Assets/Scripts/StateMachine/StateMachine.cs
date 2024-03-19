using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    public State PreviousState => _previousState;
    public float TimeInState => _timeInState;

    [SerializeField] private State _defaultState;

    private State _currentState = null;
    private State _previousState = null;
    private State _nextState = null;
    private float _timeInState;

    public void Start()
    {

        if (_defaultState != null)
        {
            SetNextState(_defaultState);
        }
        else
        {
            throw new Exception($"Default state not referenced on game object {gameObject.name}.");
        }
    }

    public void Update()
    {
        _previousState = null;

        if (_nextState != null)
        {
            SetState();
        }

        if (CurrentState != null)
        {
            CurrentState.OnStateUpdate();
            _timeInState += Time.deltaTime;
        }
    }

    private void SetState()
    {
        _currentState?.OnStateExit();
        _currentState = _nextState;
        _currentState.OnStateEnter(this);
        _timeInState = 0;
        _nextState = null;
    }

    public void SetNextState(State nextState)
    {
        if (CurrentState == nextState || (PreviousState == nextState))
            return;

        _previousState = _currentState;
        _currentState?.OnStateExit();
        _currentState = nextState;
        _currentState.OnStateEnter(this);
        _timeInState = 0;

    }
}
