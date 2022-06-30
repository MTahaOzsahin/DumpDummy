using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SurviveBoy.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        private void Awake()
        {
            //SingletonThisObject();
        }
        void SingletonThisObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LevelAsyncLoader(int index)
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(index,LoadSceneMode.Single);
        }
        public void NextLevelLoader()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
        public void LevelPanelOpener(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
        public void WelcomeLevelLoader()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(0);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
    
}
