using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    /// <summary>
    /// Factory of gameObjects, prefabs and entities
    /// </summary>
    public abstract class Factory : MonoBehaviour
    {
        /// <summary>
        /// All Factory children need to implement their own pool
        /// </summary>
        protected abstract PrefabPool Pool {
            get;
        }

        /// <summary>
        /// return a transform to instantiate the object
        /// </summary>
        /// <returns>Axis o point of spawn</returns>
        protected abstract Transform GetRespawn();

        
        
        /// <summary>
        /// Use a pool to obtain a specific entity
        /// </summary>
        protected void InstantiateEntity()
        {
            GameObject entity = Pool.GetEntity(GetRespawn());
            ConfigEntity(entity);
        }

        /// <summary>
        /// Function to initialize the entity and end the build
        /// </summary>
        /// <param name="entity">prefab obtained in the pool</param>
        protected abstract void ConfigEntity(GameObject entity);
    }
}
