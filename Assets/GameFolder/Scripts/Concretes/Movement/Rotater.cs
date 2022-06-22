using SurviveBoy.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Movement
{
    public class Rotater : IRotater
    {
        IEntityController _playerController;
        public Rotater(IEntityController entityController)
        {
            _playerController = entityController;
        }
        public void Rotate(Vector3 direction)
        {
            
        }
        public void RotateAim(Vector3 direction)
        {
           
        }
    }
}
