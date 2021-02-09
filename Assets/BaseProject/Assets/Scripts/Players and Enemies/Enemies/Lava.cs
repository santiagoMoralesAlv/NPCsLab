using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

            //other.gameObject.GetComponent<CharacterMove>().KnockBack((other.transform.position - this.transform.position).normalized);

            other.gameObject.GetComponent<CharacterHealth>().DealTotalDamage();


            Instantiate(hitEffect, other.contacts[0].point, Quaternion.identity);
        }
    }
}
