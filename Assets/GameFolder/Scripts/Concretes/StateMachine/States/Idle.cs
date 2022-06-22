using SurviveBoy.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.StateMachine.States
{
    public class Idle : IStateMachine
    {
        IAnimations _animations;
        public bool IsIdle { get; private set; }
        float currentStandTime;
        float maxStandTime;

        public Idle(IAnimations animations)
        {
            _animations = animations;
        }
        public void OnEnter()
        {
            IsIdle = true;
            maxStandTime = Random.Range(4f, 10f);
            _animations.MoveAnimation(0f);
        }
        public void Action()
        {
            currentStandTime += Time.deltaTime;
            if (currentStandTime > maxStandTime)
            {
                IsIdle = false;
            }
            Debug.Log("idle");
        }
        public void OnExit()
        {
            currentStandTime = 0f;
        }
    }
}
