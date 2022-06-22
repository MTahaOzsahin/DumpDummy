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
            Vector3 targetDistance = Vector3.Lerp(_entityController.transform.position, _playerController.transform.position,0.2f);


            _mover.Movement(-targetDistance);
            Debug.Log(targetDistance);
        }
        public void OnExit()
        {
            _animations.MoveAnimation(0f);
        }
    }
}
