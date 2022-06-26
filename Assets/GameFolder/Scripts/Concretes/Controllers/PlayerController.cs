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
        IGroundChecker groundChecker;


        bool isPlayerDead = false;

        public event System.Action OnPlayerDead;
        private void Awake()
        {
            playerInputMap = new PlayerInputMap();
            mover = new Mover(this);
            animations = new PlayerAnimation(GetComponent<Animator>());
            groundChecker = GetComponent<IGroundChecker>();

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
            GetInputs();
            OnDead();
            Animations();
            Movement();
        }
        private void FixedUpdate()
        {
            GroundChecker();
        }
        void GetInputs()
        {
            playerGetInputs = GetComponent<PlayerGetInputs>();
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
        void GroundChecker()
        {
            if (!groundChecker.IsGrounded)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0f, -100f, 0f));
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<EnemiesController>())
            {
                isPlayerDead = true;
            }
        }
        void OnDead()
        {
            if (transform.position.y < -30f)
            {
                isPlayerDead = true;
            }
            if (isPlayerDead)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                OnPlayerDead?.Invoke();
                isPlayerDead = false;
            }
        }
    }
}
