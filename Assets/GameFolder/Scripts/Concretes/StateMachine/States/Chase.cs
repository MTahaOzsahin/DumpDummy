using SurviveBoy.Abstract;
using SurviveBoy.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.StateMachine.States
{
    public class Chase : IStateMachine
    {
        IAnimations _animations;
        IMover _mover;
        Transform _playerController;
        IEntityController _entityController;

        public Chase(IEntityController entityController,Transform playerController,IAnimations animations,IMover mover)
        {
            _entityController = entityController;
            _playerController = playerController;
            _animations = animations;
            _mover = mover;
        }
        public void OnEnter()
        {
            _animations.MoveAnimation(1f);
        }
        public void Action()
        {
            Vector3 direction = (_playerController.position - _entityController.transform.position).normalized;
            Vector3 absDirection = new Vector3(Mathf.Abs(direction.x), 0f, Mathf.Abs(direction.z));
            _mover.Movement(absDirection * 0.8f);
            var targetRotation = Quaternion.LookRotation(direction);
            _entityController.transform.rotation = Quaternion.Lerp(_entityController.transform.rotation, targetRotation, 0.3f);
        }
        public void OnExit()
        {
            _animations.MoveAnimation(0f);
        }
    }
}
