using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SurviveBoy.Animations.CineMachine
{
    public class CineMachineSwitcher : MonoBehaviour
    {
        [SerializeField] InputAction inputAction;

        Animator animator;

        bool virtualCam1 = true;
        bool virtualCam2 = false;
        bool virtualCam3 = false;
        bool virtualCam4 = false;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            inputAction.Enable();
        }
        private void OnDisable()
        {
            inputAction.Disable();
        }
        private void Start()
        {
            inputAction.performed += _ => SwitchState();
        }
        void SwitchState()
        {
            if (virtualCam1)
            {
                animator.Play("Virtual Camera 2");
                virtualCam1 = false;
                virtualCam2 = true;
                virtualCam3 = false;
                virtualCam4 = false;
            }
            else if (virtualCam2)
            {
                animator.Play("Virtual Camera 3");
                virtualCam1 = false;
                virtualCam2 = false;
                virtualCam3 = true;
                virtualCam4 = false;
            }
            else if (virtualCam3)
            {
                animator.Play("Virtual Camera 4");
                virtualCam1 = false;
                virtualCam2 = false;
                virtualCam3 = false;
                virtualCam4 = true;
            }
            else if (virtualCam4)
            {
                animator.Play("Virtual Camera 1");
                virtualCam1 = true;
                virtualCam2 = false;
                virtualCam3 = false;
                virtualCam4 = false;
            }
        }
    }
}
