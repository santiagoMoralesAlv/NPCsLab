using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public Animator m_animator;
    public AudioSource m_audio;
    public GameObject bala;
    public GameObject point;
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("CinematicPlayer"))
        {
            m_animator.SetTrigger("Fire"); 
            m_audio.Play();
            Rigidbody t_bala = Instantiate(bala, point.transform.position, point.transform.rotation).GetComponent<Rigidbody>();

            t_bala.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
            t_bala = null;
        }
    }
}
