using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Characters;
using Random = UnityEngine.Random;

namespace GameLogic.Level
{
    public class EscenaryFactory : Factory
    {
        /// <summary>
        /// List of pools, a pool per module type
        /// </summary>
        [SerializeField] private PrefabPool[] modulePools;
        
        //Return a random pool
        protected override PrefabPool Pool => modulePools[Random.Range(0, modulePools.Length)];


        [SerializeField] private float moduleSize;
        private float nextModulePosition=0;
        

        private void Start()
        {
            //instantiate the firsts two modules
            base.InstantiateEntity();
            nextModulePosition = moduleSize;
            base.InstantiateEntity();
            nextModulePosition += moduleSize;
        }

        private void Update()
        {
            if (Character.Instance.gameObject.transform.position.x>=nextModulePosition-(moduleSize*2))
            {
                base.InstantiateEntity();
                nextModulePosition += moduleSize;
            }
        }

        protected override Transform GetRespawn()
        {
            return this.transform;
        }


        protected override void ConfigEntity(GameObject entity)
        {
            entity.transform.position = new Vector3(nextModulePosition,0,0);
        }
    }
}
