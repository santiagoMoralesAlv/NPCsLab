using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.Characters
{
    
    public interface Skill
    {
        event NotifyState e_NewState;
        Animator Animator { get; }
        void LevelUpgrade();
        void BuildSkill();
        void LaunchSkill();
    }
}
