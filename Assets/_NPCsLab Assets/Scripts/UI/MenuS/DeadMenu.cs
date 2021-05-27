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
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
        }
        
        void Update()
        {
            level.text = $"Metros alcanzados: {(int)(LevelControl.Instance.PassedModules)}";
            time.text = $"Segundos vivo: {(int)LevelControl.Instance.TimeRunning}";
            coins.text = $"Monedas sobrantes: {LevelControl.Instance.Coins}";
        }
    }
}