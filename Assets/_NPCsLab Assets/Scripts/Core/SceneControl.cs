using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    /// <summary>
    /// Control the changes of the scenes
    /// </summary>
    public class SceneControl : MonoBehaviour
    {
        public static SceneControl Instance {get; private set; }
        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }else if (SceneManager.GetActiveScene().name != "Menu")
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
                ReturnToMenu();
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
        
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void ReturnToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
        
        public void OpenScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
        
        public void CloseApp()
        {
            Application.Quit();
        }
    }
}
