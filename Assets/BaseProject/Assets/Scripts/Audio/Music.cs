using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip clipNormal, clipDanger;

    private void Start()
    {
        LevelManager.instance.Spawned += SetEvents;
        LevelManager.instance.DestroyCharacters += ResetEvents;
    }

    public void SetEvents()
    {
        Player.instancePlayer1.Character.GetComponent<CharacterHealth>().updateHealth += UpdateMusic;
        if (Core.NumPlayers == 2)
        {
            Player.instancePlayer2.Character.GetComponent<CharacterHealth>().updateHealth += UpdateMusic;
        }
    }
    public void ResetEvents()
    {
        Player.instancePlayer1.Character.GetComponent<CharacterHealth>().updateHealth -= UpdateMusic;
        if (Core.NumPlayers == 2)
        {
            Player.instancePlayer2.Character.GetComponent<CharacterHealth>().updateHealth -= UpdateMusic;
        }
    }

    private void UpdateMusic()
    {
        bool value;
        if (Core.NumPlayers == 2)
        {
            value = Player.instancePlayer1.Character.GetComponent<CharacterHealth>().currentHealth == 1 ||
                (Player.instancePlayer2.Character.GetComponent<CharacterHealth>().currentHealth == 1 && Core.NumPlayers == 2);
        }
        else {
            value = Player.instancePlayer1.Character.GetComponent<CharacterHealth>().currentHealth == 1;
        }


            if (value)
            {
                source.Stop();
                source.clip = clipDanger;
                source.Play();
            }
            else
            {
                if (source.clip != clipNormal)
                {
                    source.Stop();
                    source.clip = clipNormal;
                    source.Play();
                }
            }
        
    }
}
