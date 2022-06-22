using SurviveBoy.Abstract;
using SurviveBoy.Concretes.Animations;
using SurviveBoy.Concretes.Movement;
using SurviveBoy.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SurviveBoy.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController
    {
        PlayerInputMap playerInputMap;
        PlayerGetInputs playerGetInputs;
        IMover mover;
        IAnimations animations;

        private void Awake()
        {
            playerInputMap = new PlayerInputMap();
            mover = new Mover(this);
            animations = new PlayerAnimation(GetComponent<Animator>());
        }
        private void OnEnable()
        {
            playerInputMap.Enable();
        }
        private void OnDisable()
        {
            playerInputMap.Disable();
        }
        private void Update()
        {
            playerGetInputs = GetComponent<PlayerGetInputs>();
            Animations();
            Movement();
        }
        void Movement()
        {
            mover.Movement(playerGetInputs.GetDirection());
        }
        void Animations()
        {
            animations.RotateAnim(playerGetInputs.GetRotation(), playerGetInputs.GetComRotation());
            animations.MoveAnimation(Mathf.Abs(playerGetInputs.GetDirection().magnitude));
        }
    }
}
