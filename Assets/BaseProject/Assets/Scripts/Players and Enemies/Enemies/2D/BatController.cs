using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Lifetime;
using UnityEngine;

public class BatController : MonoBehaviour, PersonajeDestruible
{
    public float offsetAttack;
    [SerializeField]
    private bool inAttack = false;
    private Vector3 directionToAttack;
    [SerializeField]
    private Transform target;

    public float moveSpeed, moveSpeedInAttack;
    public Transform leftPoint, rightPoint;
    private bool movingRight;
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    private Animator anim;
    public float moveTime, waitTime;
    private float moveCount, waitCount;
    private GameObject objtarget;

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


    public void OnTriggerEnter2D(Collider2D otherC) {
        if (otherC.gameObject.CompareTag("Player") && !inAttack)
        {
            target = otherC.gameObject.transform;
            inAttack = true;
            anim.SetTrigger("inAttack");
            KamikazeAttack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (inAttack)
        {
            Dead();
        }
    }

    private void KamikazeAttack() {
        if (target.position.x < this.transform.position.x)
        {
            this.transform.eulerAngles = new Vector3(0, 0, MathUtilities.calculateAngle2DtoZ(this.transform.position, target.transform.position, offsetAttack));
            theRB.velocity = Vector2.zero;
            directionToAttack = (-Vector2.right) * moveSpeedInAttack;
            Invoke("Launch", 0.05f);
            theSR.flipX = true;

        }
        else
        {
            this.transform.eulerAngles = new Vector3(0, 0, MathUtilities.calculateAngle2DtoZ(this.transform.position, target.transform.position, offsetAttack+180));
            theRB.velocity = Vector2.zero;
            directionToAttack = (Vector2.right) * moveSpeedInAttack;
            Invoke("Launch", 0.05f);
            theSR.flipX = false;

        }
    }

    private void Launch()
    {
        theRB.AddRelativeForce(directionToAttack, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inAttack)
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
                if (moveCount <= 0)
                {
                    waitCount = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
                }
            }
            else if (waitCount > 0)
            {
                waitCount -= Time.deltaTime;
                theRB.velocity = new Vector2(0f, theRB.velocity.y);
                if (waitCount <= 0)
                {
                    moveCount = Random.Range(moveTime * 0.75f, waitTime * 1.25f);
                }
            }
        }
    }

    public void Dead()
    {
        Instantiate(deathEffect, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
