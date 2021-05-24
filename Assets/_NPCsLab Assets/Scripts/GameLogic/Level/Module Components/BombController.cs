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

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                bombAnimator.SetTrigger("Explosion");
                StartCoroutine("dead");
                player = other.gameObject;
              
            }
        }

        IEnumerator dead()
        {
            yield return new WaitForSeconds(0.15f);
            try
            {
                player.gameObject.GetComponent<Character>().Kill();
            }
            catch (Exception e)
            {
                player.transform.parent.gameObject.GetComponent<Character>().Kill();
            }
        }

    }
}
