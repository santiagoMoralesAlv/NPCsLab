using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSkillDash : Skill
{
    
    float dashSpeed;
    float dashTime;

    public Vector3 moveDirection;

    private void Start()
    {
        
        
    }
   

    protected override void PlayerInput()
    {
       

        if (Input.GetButton(character.Player.SkillAButton))
        {
            character.PlayerController.AddForce(character.Direccion*dashSpeed*Time.deltaTime);

            print("Down");

        }
        
    }

    

   
}
