using SurviveBoy.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Controllers
{
    public class PlayerGetInputs : MonoBehaviour
    {
        PlayerInputMap playerInputMap;
        Vector2 currentInputVector;
        Vector2 smoothInputVelocity;
        float smoothInputSpeed = 0.2f;
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
        public Vector3 GetDirection()
        {
            Vector2 input = playerInputMap.General.Movement.ReadValue<Vector2>();
            currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputSpeed);
            Vector3 direction = new Vector3(currentInputVector.x, 0, currentInputVector.y);
            if (direction.magnitude <= 0.1f)
            {
                return Vector3.zero;
            }
            return direction;
        }
        public float GetRotation()
        {
            Vector2 input = playerInputMap.General.Movement.ReadValue<Vector2>();
            if (input.x != 0f && input.y != 0f)
            {
                return 4f;
            }
            else if (input.x > 0f)
            {
                return 2f;
            }
            else if (input.x < 0f)
            {
                return 3f;
            }
            else if (input.y < 0f)
            {
                return 1f;
            }
            return 0f;
        }
        public float GetComRotation()
        {
            Vector2 input = playerInputMap.General.Movement.ReadValue<Vector2>();
            if (input.x > 0f && input.y > 0f)
            {
                return 0f;
            }
            else if (input.x < 0f && input.y > 0f)
            {
                return 1f;
            }
            else if (input.x > 0f && input.y < 0f)
            {
                return 2f;
            }
            else if (input.x < 0f && input.y < 0f)
            {
                return 3f;
            }
            return 0f;
        }
    }
}
