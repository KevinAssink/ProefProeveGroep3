using System;
using UnityEngine;
using Utilities;

public class StateMachine : MonoBehaviour
{
    //--------------------Private--------------------//
    [SerializeField]
    private StateMachineState _currentState;

    //--------------------Public--------------------//
    public StateMachineState _CurrentState => _currentState;

    public Action<StateMachineState> OnStateSet;

    //--------------------Functions--------------------//
    public void SetState(StateMachineState stateToSet)
    {
        _currentState = stateToSet;
        OnStateSet.Invoke(_currentState);
    }
}