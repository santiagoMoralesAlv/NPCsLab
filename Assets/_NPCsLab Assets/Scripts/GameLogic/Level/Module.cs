using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Levels
{
    public class Module : MonoBehaviour, ModuleTransform
    {
        [SerializeField]
        private float widthSize=35.99f, heightSize=16.46f;

        private float position;
        
        public float HeightSize
        {
            get => heightSize;
            set => heightSize = value;
        }

        public float WidthSize
        {
            get => widthSize;
            set => widthSize = value;
        }
        
        public float Position
        {
            get
            {
                position = transform.localPosition.x;
                return position;
            }
            set
            {
                position = value;
                transform.localPosition = new Vector3(value,0,0);
            }
        }


        public GameObject Escenary
        {
            get => escenary;
            set => escenary = value;
        }

        public GameObject[] Platforms
        {
            get => platforms;
            set => platforms = value;
        }

        public GameObject[] Pickups
        {
            get => pickups;
            set => pickups = value;
        }

        public GameObject[] Hazards
        {
            get => hazards;
            set => hazards = value;
        }

        
        private GameObject escenary;
        private GameObject[] platforms, pickups, hazards;

        private bool buildParts; 
        public void BuiltParts()
        {
            Coin[] coins = GetComponentsInChildren<Coin>();
            pickups = new GameObject[coins.Length];
            for (int i = 0; i < coins.Length; i++)
            {
                pickups[i] = coins[i].gameObject;
                pickups[i].transform.SetParent(this.transform);
            }
            
            /*(escenary)?.transform.SetParent(this.transform);
            foreach (var platform in platforms)
            {
                (platform)?.transform.SetParent(this.transform);
            }
            
            foreach (var hazard in hazards)
            {
                (hazard)?.transform.SetParent(this.transform);
            }*/
            
            gameObject.transform.SetParent(null);
        }
        
        public void ActiveParts()
        {
            if (!buildParts)
            {
                BuiltParts();
                buildParts = true;
            }
            
            foreach (var pickup in pickups)
            {
                (pickup)?.SetActive(true);
            }
            
            /*(escenary)?.SetActive(true);
            foreach (var platform in platforms)
            {
                (platform)?.SetActive(true);
            }
            
            foreach (var hazard in hazards)
            {
                (hazard)?.SetActive(true);
            }*/
            
            
            gameObject.SetActive(true);
        }
        
        public void DeactiveParts()
        {
            foreach (var pickup in pickups)
            {
                (pickup)?.SetActive(false);
            }
            
            /*(escenary)?.SetActive(true);
            foreach (var platform in platforms)
            {
                (platform)?.SetActive(true);
            }
            
            foreach (var hazard in hazards)
            {
                (hazard)?.SetActive(true);
            }*/
            
            gameObject.SetActive(false);
        }
    }
}
