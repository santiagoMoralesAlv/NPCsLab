using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PersonajeDestruible 
{
    GameObject DeathEffect {
        get;
    }

    void Dead();
}
