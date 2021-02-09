using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoverMuro : MonoBehaviour
{
  
    void Awake()
    {
        EventMoverMuro.Evento_movermuro += Movimiento;
    }

    
    public void Movimiento()
    {
        transform.position = new Vector3(53.73f, 24.54f,0);
    }
}

public static class EventMoverMuro
{
    public static Action Evento_movermuro;
}
