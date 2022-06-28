using SurviveBoy.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.StateMachine.States
{
    public class Level3Runner : IStateMachine    //Only use of level 3 runner.
    {
        IMover _mover;
        IAnimations _animations;
        Transform _playerController;
        IEntityController _entityController;
        public Level3Runner(IEntityController entityController, IMover mover, IAnimations animations, Transform playerController)
        {
            _entityController = entityController;
            _playerController = playerController;
            _mover = mover;
            _animations = animations;
        }
        public bool isLevel3 { get; private set; }
        public void OnEnter()
        {
            _animations.MoveAnimation(1f);
            isLevel3 = true;
        }
        public void Action()
        {
            Vector3 direction = (_playerController.position - _entityController.transform.position).normalized;
            _mover.Movement(direction *1f);
            var targetRotation = Quaternion.LookRotation(direction);
            _entityController.transform.GetChild(0).transform.rotation = Quaternion.Lerp(_entityController.transform.GetChild(0).transform.rotation, targetRotation, 0.05f);
        }
        public void OnExit()
        {
            _animations.MoveAnimation(0f);
            _mover.Movement(Vector3.zero);
            isLevel3 = true;
        }
    }
}
