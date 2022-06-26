using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Controllers
{
    public class CheckPointController : MonoBehaviour
    {
        bool isPassed = false;
        public bool IsPassed => isPassed;
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponent<PlayerController>() != null)
            {
                isPassed = true;
            }
        }
    }
}
