using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlatform : MonoBehaviour
{
    [SerializeField]
    bool platformCol;
    //GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        platformCol = false;
        //target = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            platformCol = true;
        }
        else
        {
            platformCol = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            platformCol = false;
        }
    }

    public void DamageEffector()
    {
        if (platformCol == true)
        {
            //PlayerHealthController.instance.DealDamage();
        }
    }
}
