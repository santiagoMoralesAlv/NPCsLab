using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Characters;
using UnityEngine.Serialization;

namespace GameLogic
{
    /// <summary>
    /// Deactivate a GameObject if  he is far from the character
    /// </summary>
    public class DeactivateByDistance : MonoBehaviour
    {
        private Transform tf;
        [SerializeField] private float maxDistance;
        
        private void Awake()
        {
            tf = this.transform;
        }

        private void Update()
        {
            if (Vector3.Distance(Character.Instance.transform.position, tf.position) > maxDistance)
            {
                gameObject.SetActive(false);
            }
        }
    }

}