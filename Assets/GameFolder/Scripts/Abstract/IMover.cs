using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Abstract
{
    public interface IMover 
    {
        void Movement(Vector3 direction);
        void MovementForPlayer(Vector3 direction);
    }
}
