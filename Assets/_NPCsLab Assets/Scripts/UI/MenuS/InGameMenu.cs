using System.Collections;
using System.Collections.Generic;
using Core;
using GameLogic.Characters;
using GameLogic.Levels;
using UnityEngine;
using UnityEngine.UI;
using NTC_MenuAndGUISystem;

namespace UI
{
    public class InGameMenu : Menu
    {
        [SerializeField] private Text currentLevel, coins;

        // Update is called once per frame
        void Update()
        {
            currentLevel.text = $"Seconds: {(int)LevelControl.Instance.TimeRunning}";
            coins.text = $"Coins: {LevelControl.Instance.Coins}";
        }
    }
}