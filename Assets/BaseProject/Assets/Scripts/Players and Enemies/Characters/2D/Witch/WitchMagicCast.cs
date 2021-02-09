using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMagicCast : Skill
{
    public Transform firePoint;
    public GameObject Magic;
    public float CastTime;
    public ParticleSystem Castparticles;

    protected override void Awake()
    {
        base.Awake();

    }

    public void Start()
    {
        Castparticles.Stop();
    }
    override protected void PlayerInput()
    {
      

        if (Input.GetButton(character.Player.SkillBButton))
        {
            Castparticles.Play();
            anim.SetBool("StartCast", true);

            if (CastTime <= 3)
            {
                CastTime += Time.deltaTime;
            }
            
            character.CanMove = false;

        }
        if (Input.GetButtonUp(character.Player.SkillBButton))
        {
            anim.SetBool("FinishCast", true);
            Castparticles.Stop();

        }
    }

    private void CastAtack()
    {
        anim.SetBool("StartCast", false);
        anim.SetBool("FinishCast", false);
        launchedSkill();    
        if (CastTime < 1)
        {
            CastTime = 1f;
        }
        Magic.transform.localScale = new Vector3(0.7f * CastTime, 0.7f * CastTime, 0);
        Instantiate(Magic, firePoint.position, firePoint.rotation);    
        Magic.transform.localScale = new Vector3(0.7f, 0.7f, 0);
        character.CanMove = true;
        CastTime = 0;

    }
}
