using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

namespace GameLogic.Levels
{
    public class Coin : MonoBehaviour
    {
        public GameObject coinSound, coinParticles;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                LevelControl.Instance.CollectCoin();
                GameObject go = Instantiate(coinSound);
                go.transform.SetParent(this.transform.parent); 
                go.transform.position = transform.position; 
                
                go = Instantiate(coinParticles);
                go.transform.SetParent(this.transform.parent); 
                go.transform.position = transform.position; 
                
                
                gameObject.SetActive(false);
                
            }
        }
    }
}
