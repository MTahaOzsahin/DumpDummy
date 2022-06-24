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

        bool isPlayerDead = false;
        public bool IsPlayerDead => isPlayerDead;

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
            if (isPlayerDead)
            {
                this.gameObject.SetActive(false);
            }
            DeadCheck();
            Animations();
            Movement();
        }
        void Movement()
        {
            mover.MovementForPlayer(playerGetInputs.GetDirection());
        }
        void Animations()
        {
            animations.RotateAnim(playerGetInputs.GetRotation(), playerGetInputs.GetComRotation());
            animations.MoveAnimation(Mathf.Abs(playerGetInputs.GetDirection().magnitude));
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<EnemiesController>())
            {
                isPlayerDead = true;
            }
        }
        void DeadCheck()
        {
            if (transform.position.y < -10f)
            {
                isPlayerDead = true;
            }
        }
    }
}
