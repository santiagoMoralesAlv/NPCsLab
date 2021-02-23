using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Characters
{
    public class Character : MonoBehaviour
    {
        // <summary> Singleton </summary>
        private static Character instance;

        public static Character Instance => instance;

        private void Awake()
        {
            //Singleton initialization
            instance = this;
        }
    }
}
