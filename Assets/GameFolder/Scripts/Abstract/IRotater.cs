using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Abstract
{
    public interface IRotater
    {
        void Rotate(Vector3 direction);
        void RotateAim(Vector3 direction);
    }
}
