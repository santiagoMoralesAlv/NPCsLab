using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Characters
{
    public class Character : MonoBehaviour, IEntity
    {
        // <summary> Singleton </summary>
        private static Character instance;
        public static Character Instance => instance;



        private GameObject deadEffect, wakeUpEffect;
        public GameObject DeadEffect => deadEffect;
        public GameObject WakeUpEffect => wakeUpEffect;
        
        private void Awake()
        {
            //Singleton initialization
            instance = this;
        }
    }
}
