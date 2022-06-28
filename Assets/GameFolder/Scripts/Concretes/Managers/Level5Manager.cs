using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SurviveBoy.Concretes.Managers
{
    public class Level5Manager : MonoBehaviour
    {
        /* This script will use for level 5 but only for this project. The general use of this script is more likely game manager. */
        TextMeshProUGUI scoreText;
        float timer;
        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
           
            scoreText.text = 0.ToString();
        }
        private void Update()
        {
            timer += Time.deltaTime;
            scoreText.text = timer.ToString("F2");
        }

    }
}
