using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherArrowLaunch : Skill
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    override protected void PlayerInput()
    {
        if (Input.GetButtonDown(character.Player.SkillAButton))
        {
            anim.SetBool("attacking", true);
            character.CanMove = false;
        }
    }

    private void Shoot()
    {
        launchedSkill();
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        anim.SetBool("attacking", false);
        character.CanMove = true;
    }
}
