using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Levels;
using UnityEngine;

public class TutorialInstancerExample : MonoBehaviour
{
    private void Awake()
    {
        LevelControl.Instance.EInit += Init;
        LevelControl.Instance.EInit += RequestInstanceModules;
    }

    public void RequestInstanceModules()
    {
        LevelControl.Instance.InstanceSpecificModule("tutorial");
        LevelControl.Instance.InstanceSpecificModule("tutorial1");
        LevelControl.Instance.InstanceSpecificModule("tutorial1");
        LevelControl.Instance.InstanceSpecificModule("tutorial");
        LevelControl.Instance.InstanceSpecificModule("tutorial2");
        LevelControl.Instance.InstanceSpecificModule("tutorial2");
        LevelControl.Instance.InstanceSpecificModule("tutorial");

    }

    public void Init()
    {
        Debug.Log("Este es un ejemplo de como ejecutar una funcion cuando se presiona play");
    }
}
