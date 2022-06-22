using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Abstract
{
    public interface IAnimations
    {
        void MoveAnimation(float moveSpeed);
        void RotateAnim(float rotationAngle, float combinationAngle);
    }
}
