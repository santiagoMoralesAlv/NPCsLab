using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2Players : MonoBehaviour
{

    public Animator TeclaA;
    public Animator TeclaD;
    public Animator TeclaQ;
    public Animator TeclaW;
    public Animator TeclaE;
    public Animator TeclaJ;
    public Animator TeclaL;
    public Animator TeclaU;
    public Animator TeclaI;
    public Animator TeclaO;



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
        if (Input.GetKeyDown(KeyCode.J))
        {
            TeclaJ.SetBool("PressJ", true);
            
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            TeclaL.SetBool("PressL", true);
           
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            TeclaU.SetBool("PressU", true);
          
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            TeclaI.SetBool("PressI", true);
            
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            TeclaO.SetBool("PressO", true);
            
        }
        if (TeclaE.GetBool("PressE") == true && TeclaW.GetBool("PressW") == true && TeclaQ.GetBool("PressQ") == true && TeclaD.GetBool("PressD") == true && TeclaA.GetBool("PressA") == true &&
            TeclaJ.GetBool("PressJ") == true && TeclaL.GetBool("PressL") == true && TeclaU.GetBool("PressU") == true && TeclaI.GetBool("PressI") == true && TeclaO.GetBool("PressO") == true)
        {
            EventMoverMuro.Evento_movermuro();
        }

    }
}
