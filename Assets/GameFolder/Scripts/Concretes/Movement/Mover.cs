using SurviveBoy.Abstract;
using SurviveBoy.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Movement
{
    public class Mover : IMover
    {
        IEntityController _playerController;
        float _moveSpeed = 5f;

        public Mover(IEntityController entityController)
        {
            _playerController = entityController;
        }
        public void Movement(Vector3 direction)
        {
            _playerController.transform.Translate(_moveSpeed * Time.deltaTime * direction);
        }
    }
}
