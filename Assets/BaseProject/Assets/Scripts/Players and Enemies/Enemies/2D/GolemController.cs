using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : MonoBehaviour, PersonajeDestruible
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool movingRight;
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    private Animator anim;
    public float moveTime, waitTime;
    private float moveCount, waitCount;


    public GameObject deathEffect;
    public GameObject DeathEffect
    {
        get { return deathEffect; } 
    }


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftPoint.parent = null;
        rightPoint.parent = null;
        movingRight = true;
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                theSR.flipX = false;
                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                theSR.flipX = true;
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            if (moveCount <=0)
            {
                waitCount = Random.Range(waitTime*0.75f, waitTime * 1.25f);
            }
            anim.SetBool("IsMoving", true);
        }
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);
            if (waitCount <= 0)
            {
                moveCount = Random.Range (moveTime * 0.75f, waitTime * 1.25f);
            }
            anim.SetBool("IsMoving", false);
        }
    }

    public void Dead ()
    {
        Instantiate(deathEffect, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
