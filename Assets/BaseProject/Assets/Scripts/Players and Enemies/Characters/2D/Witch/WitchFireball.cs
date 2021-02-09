using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchFireball : Skill
{
    public Transform firePoint;
    public GameObject Magic;
    override protected void PlayerInput()
    {
        if (Input.GetButtonDown(character.Player.SkillAButton))
        {
            character.CanMove = false;
            anim.SetTrigger("fireBall");
        }
    }

    private void Shoot()
    {
        character.CanMove = true;
        launchedSkill();
        Instantiate(Magic, firePoint.position, firePoint.rotation);
    }
}
