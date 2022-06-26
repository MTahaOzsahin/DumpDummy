using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Abstract
{
    public interface IPlayerGetInputs 
    {
        Vector3 GetDirection();
        float GetRotation();
        float GetComRotation();
    }
}
