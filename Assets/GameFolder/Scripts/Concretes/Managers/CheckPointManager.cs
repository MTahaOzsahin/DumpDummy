using SurviveBoy.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SurviveBoy.Concretes.Managers
{
    public class CheckPointManager : MonoBehaviour
    {
        CheckPointController[] checkPointControllers;
        PlayerController playerController;


        private void Awake()
        {
            checkPointControllers = GetComponentsInChildren<CheckPointController>();
            playerController = FindObjectOfType<PlayerController>();
        }
        private void OnEnable()
        {
            playerController.OnPlayerDead += CheckPointOnDead;
        }
        private void OnDisable()
        {
            playerController.OnPlayerDead -= CheckPointOnDead;
        }
        void CheckPointOnDead()
        {
            if (SceneManager.GetActiveScene().buildIndex == 3) 
            {
                SceneManager.LoadScene(3);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                playerController.transform.position = checkPointControllers.LastOrDefault(x => x.IsPassed).transform.position;
            }
            
        }
    }
}
