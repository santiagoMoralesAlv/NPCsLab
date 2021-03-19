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
            Instance = this;
        }
        

        public void ReturnToHome()
        {
            SceneManager.LoadScene("Game");
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
