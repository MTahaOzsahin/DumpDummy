using SurviveBoy.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.StateMachine
{
    public class StatesMachine 
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>();
        List<StateTransition> _anyStateTransitions = new List<StateTransition>();
        IStateMachine currentState;
        public void SetState(IStateMachine state)
        {
            if (state == currentState) return;

            currentState?.OnExit();
            currentState = state;
            currentState.OnEnter();
        }
        public void Action()
        {
            StateTransition stateTransition = CheckForTransition();
            if (stateTransition != null)
            {
                SetState(stateTransition.To);
            }
            currentState.Action();
        }
        StateTransition CheckForTransition()
        {
            foreach (StateTransition anyStateTransition in _anyStateTransitions)
            {
                if (anyStateTransition.Condition.Invoke()) return anyStateTransition;
            }
            foreach (StateTransition stateTransition in _stateTransitions)
            {
                if(stateTransition.Condition() && stateTransition.From == currentState)
                {
                    return stateTransition;
                }
            }
            return null;
        }
        public void AddTransition(IStateMachine from, IStateMachine to, System.Func<bool> condition)
        {
            StateTransition stateTransition = new StateTransition(from, to, condition);
            _stateTransitions.Add(stateTransition);
        }

        public void AddAnyState(IStateMachine to, System.Func<bool> condition)
        {
            StateTransition anyStateTransition = new StateTransition(null, to, condition);
            _anyStateTransitions.Add(anyStateTransition);
        }
    }
}
