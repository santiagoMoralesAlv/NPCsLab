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
        [SerializeField] private GameObject[] prefabs;


        private List<GameObject> prefabList ;


        private Dictionary<string, GameObject> prefabsDictionary;

        public void Init()
        {
            prefabList = new List<GameObject>();
            prefabsDictionary = new Dictionary<string, GameObject>();
            foreach (var prefab in prefabs)
            {
                prefabsDictionary.Add(prefab.name,prefab);
            }
        }

        /// <summary>
        /// Return an instance of the prefab, if there are no enough, then, it creates one
        /// </summary>
        /// <param name="tf">transform of the respawn point</param>
        /// <returns>instance</returns>
        public GameObject GetEntityByName(string t_name, Transform tf)
        {
            //Search a instance inactive to identify a entity without use
            for (int i = 0; i < prefabList.Count; i++)
            {
                if (!prefabList[i].activeInHierarchy && prefabList[i].name == t_name)
                {
                    prefabList[i].transform.SetParent(tf);
                    prefabList[i].transform.localPosition = Vector3.zero;
                    prefabList[i].transform.localRotation = Quaternion.identity;
                    prefabList[i].SetActive(true);
                    return prefabList[i]; //Break the function
                }
            }

            //if still in the function, then, it create one

            GameObject prefabToInstantiate;
            if (prefabsDictionary.TryGetValue(t_name, out prefabToInstantiate))
            {
                GameObject t_entity = Instantiate(prefabToInstantiate, tf);
                prefabList.Add(t_entity);
                t_entity.SetActive(true);
                t_entity.name = t_name;
                
                return t_entity;
            }
            else
            {
                Debug.LogError("No se encontro el id en el diccionario");
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
            //Search a instance inactive to identify a entity without use
            for (int i = 0; i < prefabList.Count; i++)
            {
                if (!prefabList[i].activeInHierarchy)
                {
                    prefabList[i].transform.SetParent(tf);
                    prefabList[i].transform.localPosition = Vector3.zero;
                    prefabList[i].transform.localRotation = Quaternion.identity;
                    prefabList[i].SetActive(true);
                    return prefabList[i]; //Break the function
                }
            }

            //if still in the function, then, it create one
            GameObject t_entity = Instantiate(prefabsDictionary.ElementAt(UnityEngine.Random.Range(0, prefabsDictionary.Count)).Value, tf);
            prefabList.Add(t_entity);
            t_entity.SetActive(true);

            return t_entity;
        }
    }
}
