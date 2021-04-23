using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    /// <summary>
    /// Pool to store and manage the entities
    /// </summary>
    [CreateAssetMenu(fileName = "Pool", menuName = "Configs/Prefab Pool", order = 2)]
    public class PrefabPool : ScriptableObject
    {
        // <summary> Prefab </summary>
        [SerializeField] private GameObject[] specifyPrefabs, randomPrefabs;
        private Dictionary<string, GameObject> specifyPrefabsDictionary, randomPrefabsDictionary;
        
        private Dictionary<string, List<GameObject>> randomInstancesDictionary;
        private List<GameObject> specifyInstancesList;


        public void Init()
        {
            specifyPrefabsDictionary = new Dictionary<string, GameObject>();
            foreach (var prefab in specifyPrefabs)
            {
                specifyPrefabsDictionary.Add(prefab.name,prefab);
            }
            randomPrefabsDictionary = new Dictionary<string, GameObject>();
            foreach (var prefab in randomPrefabs)
            {
                randomPrefabsDictionary.Add(prefab.name,prefab);
            }
            
            randomInstancesDictionary = new Dictionary<string, List<GameObject>>();
            foreach (var prefab in randomPrefabs)
            {
                randomInstancesDictionary.Add(prefab.name, new List<GameObject>());
            }
            specifyInstancesList = new List<GameObject>();
        }

        /// <summary>
        /// Return an instance of the prefab, if there are no enough, then, it creates one
        /// </summary>
        /// <param name="tf">transform of the respawn point</param>
        /// <returns>instance</returns>
        public GameObject GetEntityByName(string t_name, Transform tf)
        {
            //Search a instance inactive to identify a entity without use

            foreach (var instance in specifyInstancesList)
            {
                if (!instance.activeInHierarchy && instance.name == t_name)
                {
                    instance.transform.SetParent(tf);
                    instance.transform.localPosition = Vector3.zero;
                    instance.transform.localRotation = Quaternion.identity;
                    instance.SetActive(true);
                    return instance; //Break the function
                }
            }

            //if still in the function, then, it create one

            GameObject prefabToInstantiate;
            if (specifyPrefabsDictionary.TryGetValue(t_name, out prefabToInstantiate))
            {
                GameObject t_entity = Instantiate(prefabToInstantiate, tf);
                specifyInstancesList.Add(t_entity);
                t_entity.SetActive(true);
                t_entity.name = t_name;
                
                return t_entity;
            }
            else
            {
                throw new Exception("No se encontro el id en el diccionario");
            }
            
            
        }
        
        /// <summary>
        /// Return an instance of the prefab, if there are no enough, then, it creates one
        /// </summary>
        /// <param name="tf">transform of the respawn point</param>
        /// <returns>instance</returns>
        public GameObject GetRandomEntity(Transform tf)
        {
            GameObject prefabToInstantiate;
            string prefabName = randomPrefabsDictionary.Keys.ElementAt(UnityEngine.Random.Range(0, randomPrefabsDictionary.Count));
            
            foreach (var instance in randomInstancesDictionary[prefabName])
            {
                if (!instance.activeInHierarchy)
                {
                    instance.transform.SetParent(tf);
                    instance.transform.localPosition = Vector3.zero;
                    instance.transform.localRotation = Quaternion.identity;
                    instance.SetActive(true);
                    return instance; //Break the function
                }
            }
            
            if (randomPrefabsDictionary.TryGetValue(prefabName, out prefabToInstantiate))
            {
                GameObject t_entity = Instantiate(prefabToInstantiate, tf);
                randomInstancesDictionary[prefabName].Add(t_entity);
                t_entity.SetActive(true);
                t_entity.name = prefabName;
                
                return t_entity;
            }
            else
            {
                throw new Exception("Diccionario vacio");
            }

        }
    }
}
