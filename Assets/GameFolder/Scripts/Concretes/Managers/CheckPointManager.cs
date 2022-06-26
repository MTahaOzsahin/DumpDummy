using SurviveBoy.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            playerController.transform.position = checkPointControllers.LastOrDefault(x => x.IsPassed).transform.position;
        }
    }
}
