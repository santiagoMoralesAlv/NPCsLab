using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{


    public Animator TeclaA;
    public Animator TeclaD;
    public Animator TeclaQ;
    public Animator TeclaW;
    public Animator TeclaE;
   


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TeclaA.SetBool("PressA", true);
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TeclaD.SetBool("PressD", true);
           
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TeclaQ.SetBool("PressQ", true);
          
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TeclaW.SetBool("PressW", true);
          
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TeclaE.SetBool("PressE", true);
            
        }
        if (TeclaE.GetBool("PressE") == true && TeclaW.GetBool("PressW") == true && TeclaQ.GetBool("PressQ") == true && TeclaD.GetBool("PressD") == true && TeclaA.GetBool("PressA") == true) 
        {
            EventMoverMuro.Evento_movermuro();
        }

    }
}
