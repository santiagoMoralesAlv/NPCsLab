using UnityEngine;
using System.Collections;
using System;
using UnityEngine.InputSystem;
using Core;
using GameLogic;
using GameLogic.Levels;

[DefaultExecutionOrder(-1)]
public class CharacterMov : Singleton<CharacterMov>
{
    private static CharacterMov instance;
    public static CharacterMov Instance => instance;

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
    public int jumping;
    public int sliding;

    public AudioSource pasos;

    private Vector3 initialPosition;

    [SerializeField] private BoxCollider2D slideColl;
    private void Awake()
    {
        instance = this;
        jumping = 0;
        sliding = 0;
        rb = GetComponent<Rigidbody2D>();
        playerControls = new @CharacterMovInput();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        initialPosition = this.transform.position;
        pasos = this.GetComponent<AudioSource>();
        
        secondJump = true;
        thirdJump = true;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void OnDestroy()
    {
        SwipeDetections.ESwipeUp -= Jump;
        SwipeDetections.ESwipeDown -= Slide;
    }

    void Start()
    {

        /*
        Mouse.current.leftButton.wasPressedThisFrame
        playerControls.General.Jump. += ctx => JumpControl;
        playerControls.General.Slide.started += _ => Slide();

         playerControls.General.Slide.performed += _ => SlideControl( playerControls.General.Slide.);*/
        
        

#if UNITY_ANDROID
        playerControls.General.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.General.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);

        SwipeDetections.ESwipeUp += Jump;
        SwipeDetections.ESwipeDown += Slide;
#else

#endif


    }

    
    void Update()
    {
        if (GameStatus.Instance.Status == Status.played)
        {
            Move();
            
#if UNITY_ANDROID
            

#else
            if(Mouse.current.leftButton.wasPressedThisFrame)
                Jump();
            
            if(Mouse.current.rightButton.wasPressedThisFrame)
                Slide();
#endif
            
        }
        
        
    }

    public void StartTouchPrimary(InputAction.CallbackContext context)
    {
        (OnStartTouch)?.Invoke(Utils.ScreenToWorld(playerControls.General.PrimaryPosition.ReadValue<Vector2>()),(float)context.startTime);

    }
    
    public void EndTouchPrimary(InputAction.CallbackContext context)
    {
        (OnEndTouch)?.Invoke(Utils.ScreenToWorld(playerControls.General.PrimaryPosition.ReadValue<Vector2>()), (float) context.time);

    }
    

    [SerializeField] public bool isVark;
    [SerializeField] private ParticleSystem coinsEffect;
    private bool secondJump, thirdJump;
    [SerializeField] private AudioSource skillSound;
    public void Jump()
    {
        if (GameStatus.Instance.Status == Status.played)
        {
            if (col.IsTouchingLayers(ground))
            {
                /*this.GetComponent<AudioSource>().Stop();*/
                rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                anim.SetTrigger("Jump");
                jumping += 1;
                // StartCoroutine("stopJump");
                secondJump = true;
                thirdJump = true;
            }
            else if (thirdJump && isVark)
            {
                if (LevelControl.Instance.UseCoins())
                {
                    rb.Sleep();
                    rb.AddForce(new Vector2(0, jumpSpeed*0.75f), ForceMode2D.Impulse);
                    
                    if (secondJump)
                        secondJump = false;
                    else
                        thirdJump = false;
                    coinsEffect.Play();
                    skillSound.Play();
                }
            }
        }
    }
    
     public void Slide()
    {

        if (GameStatus.Instance.Status == Status.played)
        {
            if (col.IsTouchingLayers(ground))
            {
                /*this.GetComponent<AudioSource>().Stop();*/
                anim.SetTrigger("Slide");
                // col.enabled = false;
                // slideColl.enabled = true;
                sliding += 1;
                //rb.AddForce(new Vector2(slideSpeed,0),ForceMode2D.Impulse);
                /*StartCoroutine("stopSlide");*/
            }
            else if(!isVark)
            {
                if (LevelControl.Instance.UseCoins())
                {
                    rb.Sleep();
                    rb.AddForce(new Vector2(0, -jumpSpeed), ForceMode2D.Impulse);
                    coinsEffect.Play();
                    skillSound.Play();
                }
            }
        }

    }
    /*IEnumerator stopJump()
    {

        
        /*yield return new WaitForSeconds(0.7f);
        this.GetComponent<AudioSource>().Play();
        anim.Play("PlayerRun");
        anim.SetBool("Jump", false);#1#
        

    }*/
    /*IEnumerator stopSlide()
    {
        // yield return new WaitForSeconds(0.55f);
        // anim.Play("PlayerRun");
        // this.GetComponent<AudioSource>().Play();
        //
        // //anim.SetBool("Slide", false);
        // col.enabled = true;
        // slideColl.enabled = false;
        /*
        yield return new WaitForSeconds(0.6f);
        this.transform.position = initialPosition;
        #1#
    }*/
    private void Move()
    {
        //Read the movement value
        
        //float movementInput = playerControls.General.Move.ReadValue<float>();
        //Move the player

        Vector3 currentPosition = transform.position;
        
        currentPosition.x += (-currentPosition.x + LevelControl.Instance.CenterPoint.position.x) * speed * Time.deltaTime;
        transform.position = currentPosition;

        //Animation
        if (col.IsTouchingLayers(ground))
        {
            if(!anim.GetBool("Run"))
            anim.SetBool("Run", true);
            if(!pasos.isPlaying)
            pasos.Play();
        }
        else {
            if(anim.GetBool("Run"))
                anim.SetBool("Run", false);
            if(pasos.isPlaying)
                pasos.Stop();
            
        }
       
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
        

    }

}