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

        private GameObject escenary;
        private GameObject[] platforms, pickups, hazards;

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

        public void ActiveParts()
        {
            try
            {
                escenary.SetActive(true);
                escenary.transform.SetParent(this.transform);
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var platform in platforms)
                {
                    platform.SetActive(true);
                    platform.transform.SetParent(this.transform);
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var pickup in pickups)
                {
                    pickup.SetActive(true);
                    pickup.transform.SetParent(this.transform);
                }

            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var hazard in hazards)
                {
                    hazard.SetActive(true);
                    hazard.transform.SetParent(this.transform);
                }
            }
            catch (Exception e)
            {
            }
            
            gameObject.SetActive(true);
            gameObject.transform.SetParent(null);
        }
        
        public void DeactiveParts()
        {
            try
            {
                escenary.SetActive(false);
                escenary.transform.SetParent(null);
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var platform in platforms)
                {
                    platform.SetActive(false);
                    platform.transform.SetParent(null);
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var pickup in pickups)
                {
                    pickup.SetActive(false);
                    pickup.transform.SetParent(null);
                }
            }
            catch (Exception e)
            {
            }
            try
            {
                foreach (var hazard in hazards)
                {
                    hazard.SetActive(false);
                    hazard.transform.SetParent(null);
                }
            }
            catch (Exception e)
            {
            }
            
            gameObject.SetActive(false);
            gameObject.transform.SetParent(null);
        }
    }
}
