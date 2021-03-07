using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace UI
{
    public class MenuUI : MonoBehaviour
    {
        
        public void StartGame()
        {
            SceneControl.Instance.StartGame();
        }
    }
}
