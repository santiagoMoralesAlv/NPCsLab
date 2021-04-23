using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Characters;
using UnityEngine;

namespace GameLogic.Utilities
{
    public class Shield : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                other.gameObject.GetComponent<Character>().ShieldActive();

            }
        }
        
    }
}




   






