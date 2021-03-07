using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Levels
{
    /// <summary>
    /// Factory of gameObjects, prefabs and entities
    /// </summary>
    [CreateAssetMenu(fileName = "Factory", menuName = "Configs/Components Factory", order = 1)]
    public class ComponentsFactory : ScriptableObject
    {
        /// <summary>
        /// prefabs
        /// </summary>
        [SerializeField] protected PrefabPool pool;

        public void Init()
        {
            pool.Init();
        }

        /// <summary>
        /// Use a pool to obtain a random entity in the pool
        /// </summary>
        public GameObject InstantiateEntity(Transform tf)
        {
            GameObject entity = pool.GetRandomEntity(tf);
            ConfigEntity(entity);
            return entity;
        }

        /// <summary>
        /// Use a pool to obtain a specific entity by their Gameobject's name
        /// </summary>
        public GameObject InstantiateEntity(string prefabName, Transform tf)
        {
            GameObject entity = pool.GetEntityByName(prefabName, tf);
            ConfigEntity(entity);
            return entity;
        }

        [SerializeField] private float xMargin, yMargin;

        public GameObject[] InstantiateRandomEntitiesArray(Transform tf, Module module, int amount,
            bool RandomYPosition)
        {
            GameObject[] entities = new GameObject[amount];
            for (int i = 0; i < amount; i++)
            {
                entities[i] = InstantiateEntity(tf);
                if (RandomYPosition)
                {
                    entities[i].transform.localPosition = new Vector3(
                    (((module.WidthSize - xMargin) / amount) * i) + xMargin,
                    Random.Range(yMargin, module.HeightSize - yMargin), 0);
                }
                else
                {
                    entities[i].transform.localPosition = new Vector3(
                        (((module.WidthSize - xMargin) / amount) * i) + xMargin,
                        yMargin, 0);
                }

                
            }

            return entities;
        }

        /// <summary>
        /// Function to initialize the entity and end the build
        /// </summary>
        /// <param name="entity">prefab obtained in the pool</param>
        protected void ConfigEntity(GameObject entity)
        {
            //Si los componentes necesitan ser incializadas luego de salir de un pool entonces se hace desde aqui
        }
    }
}