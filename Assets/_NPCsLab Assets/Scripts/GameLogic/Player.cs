using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Core;
using GameLogic.Characters;
using UnityEngine;

namespace GameLogic
{
    public class Player : MonoBehaviour
    {
        public static Player Instance {get; private set; }

        private void Awake()
        {
            //Singleton
            if (Instance != null && Instance != this)
            {
                Destroy(Instance.gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        [SerializeField] private GameObject[] characterPreFab;
        private GameObject i_character;
        public void SetCharacter(int index) {
            i_character = characterPreFab[index];
        }
        public void InstanceCharacter(float yPos) {
            Instantiate(i_character, new Vector3(0.0f, yPos, 0.0f), Quaternion.identity);
        }
    }

}