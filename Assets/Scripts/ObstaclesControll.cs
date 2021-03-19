using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesControll : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

        }
    }
}
