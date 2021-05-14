﻿using System;
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
        [SerializeField] private Text currentLevel, coins, highScore;

        private void Start()
        {
            highScore.text = $"HighScore: 0 M";
        }

        
        // Update is called once per frame
        void Update()
        {
            highScore.text = $"HighScore: {(int)(LevelControl.Instance.MaxPassedModules/5)} M";
            currentLevel.text = $"Meters: {(int)(LevelControl.Instance.TimeRunning/5)} M";
            coins.text = $"Coins: {LevelControl.Instance.Coins}";
        }
    }
}