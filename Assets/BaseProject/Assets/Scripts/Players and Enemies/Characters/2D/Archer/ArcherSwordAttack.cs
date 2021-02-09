using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSwordAttack : Skill
{
    public Transform attackPoint;
    public float meleeAttackRange = 0.5f;
    public LayerMask enemyLayers;
   
    override protected void PlayerInput()
    {
        if (Input.GetButtonDown(character.Player.SkillBButton))
        {
            anim.SetTrigger("melee_attacking");
        }
    }

    public void MeleeAttack()
    {
        launchedSkill();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, meleeAttackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {

            enemy.gameObject.GetComponent<PersonajeDestruible>().Dead();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
        }
    }
}
