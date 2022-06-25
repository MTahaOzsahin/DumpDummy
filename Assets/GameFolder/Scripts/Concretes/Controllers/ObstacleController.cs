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
        [SerializeField] Vector3 rotationDirection;
        [SerializeField] float moveSpeed;
        [SerializeField] float moveRate;
        [SerializeField] float rotationSpeed;
        [SerializeField] float rotationRate;
        [SerializeField] float rotationAngle;

        float moveTimer = 0f;
        float rotateTimer = 0f;

        private void FixedUpdate()
        {
            Movement();
            Rotation();
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
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<PlayerController>() != null)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -100f, 0)*Time.fixedDeltaTime);
            }
        }
        void Rotation()
        {
            if (!isMove) return;
            rotateTimer += Time.deltaTime;
            if (rotateTimer > rotationRate)
            {
                transform.Rotate(rotationDirection, rotationAngle);
                if (rotateTimer > rotationRate * 2)
                {
                    transform.Rotate(rotationDirection, -rotationAngle * 2);
                    if (rotateTimer > rotationRate * 3)
                    {
                        rotateTimer = 0f;
                    }
                }
            }
        }
    }
}
