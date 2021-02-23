using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    /// <summary>
    /// Pool to store and manage the entities
    /// </summary>
    public class PrefabPool : MonoBehaviour
    {
        // <summary> Prefab </summary>
        [SerializeField] private GameObject prefab;


        [SerializeField] private List<GameObject> prefabList = new List<GameObject>();


        /// <summary>
        /// Return an instance of the prefab, if there are no enough, then, it creates one
        /// </summary>
        /// <param name="tf">transform of the respawn point</param>
        /// <returns>instance</returns>
        public GameObject GetEntity(Transform tf)
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
            GameObject t_entity = Instantiate(prefab, tf);
            prefabList.Add(t_entity);

            return t_entity;
        }
    }
}
