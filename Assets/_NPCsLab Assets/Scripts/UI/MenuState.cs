using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using NTC_MenuAndGUISystem;
using UnityEngine;

namespace UI
{
    public class MenuState : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameStatus.Instance.e_NewStatus += NewGameStatus;
        }

        // Update is called once per frame
        void NewGameStatus(Status _status, bool inTransition)
        {
            
            if (inTransition)
            {
                MenuManager.Instance.CloseAndCleanAll();
                
                switch (_status)
                {
                    case Status.stopped:
                        MenuManager.Instance.OpenMenu("dead");
                        break;
                    case Status.played:
                        MenuManager.Instance.OpenMenu("inGame");
                        break;
                    case Status.paused:
                        MenuManager.Instance.OpenMenu("pause");
                        break;
                } 
            }
        }
    }
}