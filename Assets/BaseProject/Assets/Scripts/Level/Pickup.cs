using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType { 
    gem,
    cherry,
    key
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public GameObject pickupEffect;
    

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(type == PickupType.gem)
            {
                PlayerStatsManager.instance.CollectGem(1);
            } else if(type == PickupType.cherry)
            {
                other.GetComponent<CharacterHealth>().HealPlayer();
            }else if (type == PickupType.key)
            {
                PlayerStatsManager.instance.CollectKey(1);
            }

            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
