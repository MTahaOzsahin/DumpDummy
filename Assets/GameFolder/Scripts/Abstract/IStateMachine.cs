using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Abstract
{
    public interface IStateMachine
    {
        void OnEnter();
        void Action();
        void OnExit();

    }
}
