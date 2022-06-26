using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Controllers
{
    public class FinisherController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Next Level");
            }
        }
    }
}
