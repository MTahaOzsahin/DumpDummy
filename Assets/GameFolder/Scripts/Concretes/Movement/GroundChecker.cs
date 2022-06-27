using SurviveBoy.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Movement
{
    public class GroundChecker : MonoBehaviour, IGroundChecker
    {
        [SerializeField] Transform[] groundCheckerTransforms;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float maxDistance = 0.1f;
        bool isGrounded = false;
        public bool IsGrounded => isGrounded;

        private void Update()
        {
            foreach (Transform transform in groundCheckerTransforms)
            {
                CheckIfGrounded(transform);
                if (isGrounded) break;
            }
        }

        public void CheckIfGrounded(Transform groundCheckerTransform)
        {
            if (Physics.Raycast(groundCheckerTransform.position, groundCheckerTransform.forward, out RaycastHit hit, maxDistance, groundLayer))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            Debug.DrawRay(groundCheckerTransform.position, groundCheckerTransform.forward * maxDistance, Color.green);
        }

        
    }
}
