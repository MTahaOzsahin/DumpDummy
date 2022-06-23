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
        IEntityController _entityController;
        Transform[] _patrols;
        Transform _currentPatrol;
        int _patrolIndex = 0;

        public Walk(IEntityController entityController,IMover mover,IAnimations animations,params Transform[] patrols)
        {
            _entityController = entityController;
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
            if (Vector3.Distance(_entityController.transform.position, _currentPatrol.position) <= 0.2f)
            {
                IsWalking = false;
                return;
            }
            Vector3 _direction = (_currentPatrol.position - _entityController.transform.position).normalized;
            _mover.Movement(_direction * 0.7f);
            var targetRotation = Quaternion.LookRotation(_direction);
            _entityController.transform.GetChild(0).transform.rotation = Quaternion.Lerp(_entityController.transform.GetChild(0).transform.rotation, targetRotation, 0.05f);
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
