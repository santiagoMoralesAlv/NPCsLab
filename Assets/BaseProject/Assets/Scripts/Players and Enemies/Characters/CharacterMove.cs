using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Rigidbody))]

public class CharacterMove : MonoBehaviour
{
    #region basic parameters
    private Player player;

    private Rigidbody playerController;
    private Transform tf;
    private Animator anim;
    private Transform groundCheck;
    #endregion

    #region movement parameters
    [SerializeField]
    private float baseMoveSpeed;
    [SerializeField]
    private float currentMoveSpeed;

    private float turSmoothVelocity;
    private float turnSmoothTime;
    Vector3 direccion;
    float horizontal;
    float vertical;



    [SerializeField]
    private bool canMove, inGround;
    public static bool canGlobalMove = true;
    [SerializeField]
    private LayerMask whatIsGround;
    #endregion

    #region Knockback parameters;
    [SerializeField]
    private float knockBackLenght, knockBackForce;//For enemies collsion
    [SerializeField]
    private bool inKnock; //while it's knockout can't move
    private float verticalVelocity;
    private float horizontalVelocity;
    private float m_RunCycleLegOffset=0.2f;
    //private float m_AnimSpeedMultiplier=1f;

    #endregion

    #region Properties
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool InKnock { get => inKnock; }

    public Player Player { get => player; set => player = value; }
    public float CurrentMoveSpeed { get => currentMoveSpeed; set => currentMoveSpeed = value; }
    public Rigidbody PlayerController { get => playerController; set => playerController = value; }
    public Vector3 Direccion { get => direccion; set => direccion = value; }
    #endregion

    private void Awake()
    {
        PlayerController = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();


        PlayerStatsManager.instance.UpdatedStats += LevelUpUpgrades;
        LevelUpUpgrades();


        CurrentMoveSpeed = baseMoveSpeed;
    }

  
    void Update()
    {
        
            if (canMove)//the movement can blocked for a knockout or a hability
            {
                MovePlayer();

            }


        verticalVelocity = Math.Abs(vertical);
        horizontalVelocity = Math.Abs(horizontal);


        UpdateAnimator(Direccion);
    }

    

    private void MovePlayer()
    {
        horizontal = 0;
        vertical = 0; 
        
        if (canGlobalMove)
        {
            //horizontal = Input.GetAxis(Player.Horizontal);
            horizontal = Input.GetAxis(Player.MovAxis);
            vertical = Input.GetAxis(Player.JumpAxis);
        }

        Direccion = new Vector3(horizontal, 0, vertical).normalized;


        if (inGround && Direccion.magnitude>0 )
        {
            float targetAngle = Mathf.Atan2(Direccion.x, Direccion.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);


            //playerController.Move(direccion*currentMoveSpeed*Time.deltaTime);
            verticalVelocity = Math.Abs(vertical);
            horizontalVelocity = Math.Abs(horizontal);
        }

    }
    void UpdateAnimator(Vector3 move)
    {
        // update the animator parameters
        if (verticalVelocity > 0.1f || horizontalVelocity > 0.1f)
        {
            anim.SetFloat("Forward", Mathf.Max(verticalVelocity, horizontalVelocity), .1f, Time.deltaTime);
            
        }
        else
        {
            anim.SetFloat("Forward", 0);
        }
        
    }
    public void LevelUpUpgrades()
    {

        //hay un try catch pq habia un bug raro, por el momento esto deberia de servir aunque no es muy seguro si el bug sigue existiendo
        try
        {
            CurrentMoveSpeed = ( 0.15f * PlayerStatsManager.instance.CharactersLevel) + baseMoveSpeed + ((PlayerStatsManager.instance.velocityBonus));
            anim.SetFloat("Level", currentMoveSpeed);
        }
        catch
        {
            //si aparece el bug se desuscribe el personaje del evento
            PlayerStatsManager.instance.UpdatedStats -= LevelUpUpgrades;
        }
    }

}
