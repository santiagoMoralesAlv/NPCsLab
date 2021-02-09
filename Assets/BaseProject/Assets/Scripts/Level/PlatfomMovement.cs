using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfomMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject startPoint;
    [SerializeField]
    private GameObject endPoint;
    [SerializeField]
    private float PSpeed;
    [SerializeField]
    private bool goingRight;

    [SerializeField]
    private bool startToRight;

    //player setup
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (startToRight)
        {
            transform.position = startPoint.transform.position;
        }
        else
        {
            transform.position = endPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!goingRight)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, PSpeed * Time.deltaTime);
            if (transform.position == endPoint.transform.position)
            {
                goingRight = true;
                
            }

        }

        if (goingRight)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, PSpeed * Time.deltaTime);
            if (transform.position == startPoint.transform.position)
            {
                goingRight = false;
                
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //player.GetComponent<PlayerController>().moveSpeed = 0f;
            //player.GetComponent<PlayerController>().isGrounded = false;

            col.gameObject.transform.parent = this.transform;
        }
 
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = null;
        }
    }
}
