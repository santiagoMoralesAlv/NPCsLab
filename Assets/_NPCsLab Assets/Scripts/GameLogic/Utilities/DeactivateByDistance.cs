using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Characters;

namespace GameLogic
{
    public class DeactivateByDistance : MonoBehaviour
    {
        private Transform tf;
        [SerializeField] private float distance;
        
        private void Awake()
        {
            tf = this.transform;
        }

        private void Update()
        {
            if (Vector3.Distance(Character.Instance.transform.position, tf.position) > distance)
            {
                gameObject.SetActive(false);
            }
        }
    }

}