using System.Collections;
using System.Collections.Generic;
using Core;
using NTC_MenuAndGUISystem;
using UnityEngine;

namespace UI
{
    public class HomeMenu : Menu
    {
        public void PlayGame()
        {
            GameStatus.Instance.Play();
        }
    }
}