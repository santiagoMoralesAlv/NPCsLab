using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Characters;
using UnityEngine;


namespace GameLogic.Utilities
{
    public class BombController : MonoBehaviour
    {
        private Animator bombAnimator;
        private GameObject player;
        private void Awake()
        {
            bombAnimator = GetComponent<Animator>();
        }

        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                bombAnimator.SetTrigger("Explote");
                player = other.gameObject;
                
                player.gameObject.GetComponent<Character>().Kill();
              
            }
        }

        

    }
}
