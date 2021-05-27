using System;
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
        [SerializeField] private Text currentLevel, coins, coinsCost, highScore;

        [SerializeField] private Image skill;
        [SerializeField] private Sprite[] skillSprites;

        private void Start()
        {
            highScore.text = $"Record Global: 69 M";
        }

        
        // Update is called once per frame
        void Update()
        {
            highScore.text = $"Record Global: {(int)(LevelControl.Instance.MaxPassedModules)} M";
            currentLevel.text = $"Metros: {(int)(LevelControl.Instance.PassedModules)} M";
            coins.text = $"Monedas: {LevelControl.Instance.Coins}";
            coinsCost.text = $"Costo: {LevelControl.Instance.CoinsCost}";

            int i = (int)(Mathf.Clamp(LevelControl.Instance.Coins, 0, LevelControl.Instance.CoinsCost)* (3f/LevelControl.Instance.CoinsCost));

            
            skill.sprite = skillSprites[3-i];
        }
    }
}