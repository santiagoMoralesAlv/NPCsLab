using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Core;
using GameLogic.Characters;
using GameLogic.Levels;
using UnityEngine;

namespace GameLogic
{
    public class Player : MonoBehaviour
    {
        public static Player Instance {get; private set; }

        private GameObject character;

        [SerializeField] private Transform respawnPoint;
        
        
        
        private void Awake()
        {
            Instance = this;
            NewCharacter(0);
        }

        [SerializeField] private GameObject[] characterPreFab;
        private GameObject i_character;
        public void NewCharacter(int index) {
            Destroy(this.i_character);
            i_character = Instantiate(characterPreFab[index], respawnPoint.position, Quaternion.identity);
            
        }
    }

}