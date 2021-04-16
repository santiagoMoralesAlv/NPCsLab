using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameLogic.Characters
{
    public class Shield : MonoBehaviour
    {         
        [SerializeField]
        private GameObject player;
        private Character cr;
       private void Awake()
         {                
            cr = player.gameObject.GetComponent<Character>();
        }
        private void Update()
        {
            //UseShield(cr.shieldUsed);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                cr.isShieldActive = true;
                Destroy(this);
            }
        }
        /*public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) this.transform.position = collision.transform.position + new Vector3(0f, 0.7f, 0f);
        }
        public void UseShield(bool used)
        {
            if (used == true)
            {
                Destroy(this);
            }
            else return;
        }*/
    }

}

   






