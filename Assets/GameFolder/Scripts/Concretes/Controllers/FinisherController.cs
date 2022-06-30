using SurviveBoy.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SurviveBoy.Concretes.Controllers
{
    public class FinisherController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponent<PlayerController>() != null)
            {
                int buildIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadSceneAsync(buildIndex + 1);
                //GameManager.Instance.NextLevelLoader();
            }
        }
    }
}
