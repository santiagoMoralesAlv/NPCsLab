using System.Collections;
using System.Collections.Generic;
using Core;
using GameLogic.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField] private Text currentLevel;

        // Update is called once per frame
        void Update()
        {
            currentLevel.text = $"Segundos: {(int)LevelControl.Instance.TimeRunning}";
        }

        public void ReturnToMenu()
        {
            
            SceneControl.Instance.ReturnToMenu();
        }
    }
}