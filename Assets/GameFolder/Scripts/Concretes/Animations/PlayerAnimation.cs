using SurviveBoy.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Animations
{
    public class PlayerAnimation : IAnimations
    {
        Animator _animator;
        public PlayerAnimation(Animator animator)
        {
            _animator = animator;
        }
        public void RotateAnim(float rotationAngle,float combinationAngle)
        {
            _animator.SetFloat("rotationAngle", rotationAngle);
            _animator.SetFloat("combinationAngle", combinationAngle);
        }
        public void MoveAnimation(float moveSpeed)
        {
            _animator.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));
        }
    }
}
