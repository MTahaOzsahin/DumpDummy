using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Controllers
{
    public class ObstacleController : MonoBehaviour
    {
        [Header("Will this object move")]
        [SerializeField] bool isMove;
        [Header("Values")]
        [SerializeField] Vector3 moveDirection;
        [SerializeField] float moveSpeed;
        [SerializeField] float moveRate;

        float moveTimer = 0f;

        private void FixedUpdate()
        {
            Movement();
        }
        void Movement()
        {
            if (!isMove) return;
            moveTimer += Time.deltaTime;
            if (moveTimer > moveRate)
            {
                transform.Translate(moveSpeed * Time.deltaTime * moveDirection);
                if (moveTimer > moveRate*2)
                {
                    transform.Translate(moveSpeed * Time.deltaTime * -moveDirection *2);
                    if (moveTimer > moveRate*3)
                    {
                        moveTimer = 0f;
                    }
                }   
            }
        }
    }
}
