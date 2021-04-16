using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Characters;
using UnityEngine;


namespace GameLogic.Utilities
{
    public class shieldPlayer : MonoBehaviour
    {
        float time = 0f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Bomb"))
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }

        void Update()
        {
            if (gameObject.activeSelf == true) StartCoroutine("deactivateShield");
        }
        IEnumerator deactivateShield()
        {
            yield return new WaitForSeconds(10f);
            gameObject.SetActive(false);
        }

    }
       
 }



