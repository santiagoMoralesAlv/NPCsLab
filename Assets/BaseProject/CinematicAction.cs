using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicAction : MonoBehaviour
{
    public static bool CanMove;

    private bool wasActive;
    [SerializeField]
    private PlayableDirector director;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && wasActive == false)
        {
            CharacterMove.canGlobalMove = false;
            director.Play();
            wasActive = true;
        }
    }

}
