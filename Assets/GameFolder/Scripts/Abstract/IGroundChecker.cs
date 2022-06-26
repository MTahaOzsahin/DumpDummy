using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Abstract
{
    public interface IGroundChecker
    {
        bool IsGrounded { get; }
    }

}
