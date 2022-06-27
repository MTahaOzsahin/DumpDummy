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

        [SerializeField] bool level3 = false;

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
            if (level3) //Level 3 will realod all scene. This part will be moved game manager later.
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                playerController.transform.position = checkPointControllers.LastOrDefault(x => x.IsPassed).transform.position;
            }
            
        }
    }
}
