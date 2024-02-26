using System;
using UnityEngine;
using Utilities;

namespace StateMachineNameSpace
{
    public class StateMachine : SingletonBehaviour<StateMachine>
    {
        //--------------------Private--------------------//
        [SerializeField]
        private StateMachineState _currentState;

        //--------------------Public--------------------//
        public StateMachineState _CurrentState => _currentState;

        public Action<StateMachineState> OnStateSet;

        //--------------------Functions--------------------//
        /// <summary>
        /// Function to set the state of the statemachine, fires a event
        /// </summary>
        /// <param name="stateToSet">The state to set the state machine to</param>
        public void SetState(StateMachineState stateToSet)
        {
            _currentState = stateToSet;
            OnStateSet.Invoke(_currentState);
        }
    }
}