using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SurviveBoy.Concretes.Controllers
{
    public class EnemiesRunnerController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.GetComponent<PlayerController>())
            {
                int buildIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadSceneAsync(buildIndex + 1, LoadSceneMode.Single);
            }
        }
    }
}
