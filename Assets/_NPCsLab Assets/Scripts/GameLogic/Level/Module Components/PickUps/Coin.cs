using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Levels
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
