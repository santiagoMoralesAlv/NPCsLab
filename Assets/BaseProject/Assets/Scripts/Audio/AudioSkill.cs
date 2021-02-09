using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSkill : MonoBehaviour
{
    [SerializeField]
    private Skill skillA, skillB;

    [SerializeField]
    private AudioSource clipA, clipB;

   private void Awake()
    {
        skillA.launchedSkill += PlaySkillASound;
        skillB.launchedSkill += PlaySkillBSound;
    }

    public void PlaySkillASound()
    {
        clipA.Stop();
        clipA.Play();
    }

    public void PlaySkillBSound()
    {
        clipB.Stop();
        clipB.Play();
    }
}
