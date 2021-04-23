using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Levels
{
    public class Coin : MonoBehaviour
    {
        public GameObject coinSound;
        public GameObject coinParticles;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Si toca escudo");
                LevelControl.Instance.CollectCoin();
                Instantiate(coinSound, this.transform.position, coinParticles.transform.rotation);
                this.gameObject.SetActive(false);

            }
        }
    }
}
