using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSwordAttack : Skill
{
    public Transform firePoint;
    public float meleeAttackRange = 0.5f;
    public LayerMask enemyLayers;


    override protected void PlayerInput()
    {
        if (Input.GetButtonDown(character.Player.SkillAButton))
        {
            anim.SetTrigger("melee_attacking");
        }
    }

    private void MeleeAttack()
    {
        launchedSkill();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firePoint.position, meleeAttackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            enemy.gameObject.GetComponent<PersonajeDestruible>().Dead();
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (firePoint == null)
            return;

        Gizmos.DrawWireSphere(firePoint.position, meleeAttackRange);
    }
}
