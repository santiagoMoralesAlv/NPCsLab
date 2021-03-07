using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMov : MonoBehaviour
{

   [SerializeField] public float speed, jumpSpeed,slideSpeed, hurtForce;

   [SerializeField] private LayerMask ground;

    private CharacterMovement playerActionControls;

    public float crouchingSpeed = 4f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col;
    private Animator anim;

    [SerializeField] private BoxCollider2D slideColl;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerActionControls = new CharacterMovement();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }
    void Start()
    {
        playerActionControls.General.Jump.performed += ctx => Jump(ctx.ReadValue<float>());
        playerActionControls.General.Slide.performed += _ => Slide();

    }

    void Update()
    {
         Move();
    }

    private void Jump(float val)
    {
        if (val == 1 && col.IsTouchingLayers(ground))
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            anim.SetBool("Jump",true);
            StartCoroutine("stopJump");
        }
    }
    
     private void Slide()
    {

         if (col.IsTouchingLayers(ground))
         {            
            anim.SetBool("Slide",true);
            col.enabled = false;
            slideColl.enabled=true;
            rb.AddForce(new Vector2(slideSpeed,0),ForceMode2D.Impulse);
            StartCoroutine("stopSlide");
        }
              
    }
    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(0.9f);
        anim.Play("PlayerRun");
        anim.SetBool("Jump", false);
        
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.4f);
        anim.Play("PlayerRun");
        anim.SetBool("Slide", false);
        col.enabled = true;
        slideColl.enabled = false;
    }
    private void Move()
    {
        //Read the movement value

        float movementInput = playerActionControls.General.Move.ReadValue<float>();
        //Move the player

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;

        //Animation
        if (movementInput != 0) anim.SetBool("Run", true);
        else anim.SetBool("Run", false);
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (other.gameObject.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
            }
           
        }
        if (other.gameObject.tag == "Death")
        {
            sr.color = new Color (1,0,0,1);
        }

    }

}