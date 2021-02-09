using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightShieldDefence : Skill
{

    public SpriteRenderer theSR;
    private CharacterHealth def;
    public ParticleSystem Defparticles;

    protected override void Awake()
    {
        base.Awake();
        def = GetComponent<CharacterHealth>();
        Defparticles.Stop();
    }

    override protected void PlayerInput()
    {
        if (Input.GetButtonDown(character.Player.SkillBButton))
        {
            anim.SetTrigger("defence");
        }
    }

    private void StartDefence()
    {
        character.CanMove = false;
        launchedSkill();
        Defparticles.Play();
        def.invencibleCounter = 1f; //se le da un poco mas tiempo de invencibilidad para q se mueva libremente y salga de peligro
        Invoke("StopDefence", 1);
     
    }

    public void StopDefence()
    {
        character.CanMove = true;
        Defparticles.Stop();
    }
}
