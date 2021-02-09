using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martillo : MonoBehaviour
{
    public float velocity;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("CinematicPlayer"))
        {
            this.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right* velocity, ForceMode.Force);
        }
    }
}
