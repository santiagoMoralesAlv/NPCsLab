using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed =20f;
    private Rigidbody rb;
    public GameObject hitEffect;


    public GameObject collecteable;
    [Range(0, 100)] public float chanceToDrop;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        rb.AddForce(transform.right * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy Volador")
        {
            other.gameObject.GetComponent<PersonajeDestruible>().Dead();

            float dropSelect = Random.Range(0, 100f);

            if (dropSelect <= chanceToDrop)
            {
                Instantiate(collecteable, other.transform.position, other.transform.rotation);
            }
        }


        Instantiate(hitEffect, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
        
         
    }

}
