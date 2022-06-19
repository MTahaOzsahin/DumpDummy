using SurviveBoy.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        PlayerInputMap playerInputMap;

        [SerializeField] float moveSpeed=5f;

        private void Awake()
        {
            playerInputMap = new PlayerInputMap();
        }
        private void OnEnable()
        {
            playerInputMap.Enable();
        }
        private void OnDisable()
        {
            playerInputMap.Disable();
        }
        private void FixedUpdate()
        {
            Movement();
        }
        public void Movement()
        {
            Vector2 direction = playerInputMap.General.Movement.ReadValue<Vector2>();
            Vector3 v3direction = new Vector3(direction.x, 0f, direction.y);
            transform.Translate(moveSpeed * Time.deltaTime * v3direction);
        }

    }
}
