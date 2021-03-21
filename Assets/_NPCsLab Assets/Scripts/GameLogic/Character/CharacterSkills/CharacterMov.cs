using UnityEngine;
using System.Collections;
using System;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class CharacterMov : Singleton<CharacterMov>
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion

    [SerializeField] public float speed, jumpSpeed, slideSpeed, hurtForce;

    [SerializeField] private LayerMask ground;

    private @CharacterMovInput playerControls;

    public float crouchingSpeed = 4f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col;
    private Animator anim;

    private Vector3 initialPosition;

    [SerializeField] private BoxCollider2D slideColl;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new @CharacterMovInput();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        initialPosition = this.transform.position;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    void Start()
    {
        playerControls.General.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.General.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);


        playerControls.General.Jump.performed += ctx => Jump(ctx.ReadValue<float>());
        playerControls.General.Slide.performed += _ => Slide();

    }

    void Update()
    {
        Move();
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(playerControls.General.PrimaryPosition.ReadValue<Vector2>()),(float)context.startTime);
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Utils.ScreenToWorld( playerControls.General.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }
    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld( playerControls.General.PrimaryPosition.ReadValue<Vector2>());
    }
    public void Jump(float val)
    {
        if (val == 1 && col.IsTouchingLayers(ground))
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            anim.SetBool("Jump",true);
            StartCoroutine("stopJump");
        }
    }
    
     public void Slide()
    {

         if (col.IsTouchingLayers(ground))
         {            
            anim.SetBool("Slide",true);
            col.enabled = false;
            slideColl.enabled=true;
            //rb.AddForce(new Vector2(slideSpeed,0),ForceMode2D.Impulse);
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
        yield return new WaitForSeconds(0.7f);
        anim.Play("PlayerRun");
        anim.SetBool("Slide", false);
        col.enabled = true;
        slideColl.enabled = false;

        /*yield return new WaitForSeconds(0.6f);
        this.transform.position = initialPosition;*/

    }
    private void Move()
    {
        //Read the movement value

        float movementInput = playerControls.General.Move.ReadValue<float>();
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