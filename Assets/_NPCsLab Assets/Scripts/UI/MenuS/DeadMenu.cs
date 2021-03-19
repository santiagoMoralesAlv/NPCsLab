using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using NTC_MenuAndGUISystem;
using UnityEngine.UI;
using GameLogic.Levels;

namespace UI
{
    public class DeadMenu : Menu
    {
        [SerializeField] private Text level, time, coins;

        public void Replay()
        {
            MenuManager.Instance.CloseAndCleanAll();
            SceneControl.Instance.ReturnToHome();
        }
        
        void Update()
        {
            level.text = $"Level reached: {LevelControl.Instance.PassedModules}";
            time.text = $"Seconds: {(int)LevelControl.Instance.TimeRunning}";
            coins.text = $"Collected coins: {LevelControl.Instance.Coins}";
        }
    }
}