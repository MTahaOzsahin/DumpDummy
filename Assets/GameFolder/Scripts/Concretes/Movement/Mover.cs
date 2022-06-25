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
        Rigidbody playerRigibody;
        float _moveSpeed = 5f;
        public Mover(IEntityController entityController)
        {
            _playerController = entityController;
        }
        public void Movement(Vector3 direction)
        {
            _playerController.transform.Translate(_moveSpeed * Time.deltaTime * direction);
        }
        public void MovementForPlayer(Vector3 direction)
        {
            playerRigibody = _playerController.transform.GetComponent<Rigidbody>();
            if (direction == Vector3.zero)
            {
                playerRigibody.velocity = new Vector3(0f, playerRigibody.velocity.y, 0f);
            }
            playerRigibody.AddForce(direction * 15f);
        }
    }
}
