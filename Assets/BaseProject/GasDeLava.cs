using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasDeLava : MonoBehaviour
{
    public float forceJump, forceFloat, timeWithoutGas;

    private float time;
    [SerializeField]
    private bool used;

    [SerializeField]
    private ParticleSystem particles;

    private void Update()
    {
        if (used) {
            time -= Time.deltaTime ;

            if (time <= 0) {
                used = false;
                particles.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !used) {
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
            used = true;
            time = timeWithoutGas;
            particles.Play();


            other.gameObject.GetComponent<CharacterHealth>().DealDamage();
            other.gameObject.GetComponent<CharacterHealth>().DealDamage();
            other.gameObject.GetComponent<CharacterHealth>().DealDamage();
        }

        try
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0, forceFloat, 0), ForceMode.Force);
                }
        catch { 
        
        }
    }
}
