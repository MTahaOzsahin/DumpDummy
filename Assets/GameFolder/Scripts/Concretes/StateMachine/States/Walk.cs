using SurviveBoy.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.StateMachine.States
{
    public class Walk : IStateMachine
    {
        IMover _mover;
        IAnimations _animations;
        Transform[] _patrols;
        Transform _currentPatrol;
        int _patrolIndex = 0;
        public Walk(IMover mover,IAnimations animations,params Transform[] patrols)
        {
            _mover = mover;
            _animations = animations;
            _patrols = patrols;
        }
        public bool IsWalking { get; private set; }
        public void OnEnter()
        {
            if (_patrols.Length < 1) return;
            _currentPatrol = _patrols[_patrolIndex];
            IsWalking = true;
            _animations.MoveAnimation(0.15f);
        }
        public void Action()
        {
            if (_currentPatrol == null) return;
            _mover.Movement(new Vector3(0f,0f,0.15f));
            Debug.Log("walk");

        }
        public void OnExit()
        {
            _animations.MoveAnimation(0f);
            _mover.Movement(Vector3.zero);
            _patrolIndex++;
            if (_patrolIndex >= _patrols.Length)
            {
                _patrolIndex = 0;
            }
        }
    }
}
