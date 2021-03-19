using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTC_MenuAndGUISystem
{
    public class Navigator : MonoBehaviour
    {
        public void OpenMenu(string menuName) {
            MenuManager.Instance.OpenMenu(menuName);
        }
        public void ReturnToParent(string menuName)
        {
            MenuManager.Instance.ReturnToParent(menuName);
        }
        public void CloseAll()
        {
            MenuManager.Instance.CloseAndCleanAll();
        }
    }
}
