using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Characters
{
    public enum PowerUpState
    {
        available,
        upgraded,
        active
    }
    public abstract class PowerUpSkill : MonoBehaviour, Skill
    {
        public event NotifyState e_NewState;
        
        private PowerUpState state;
        public PowerUpState State => state;
        
        protected Animator _animator;
        public Animator Animator => _animator;

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
        }

        protected void SetNewState(PowerUpState newState)
        {
            state = newState;
            try
            {
                e_NewState(state.ToString());
            }
            catch (Exception e)
            {
                //Without subscriptions
            }

        }
        public virtual void BuildSkill()
        {
            level = 0;
            SetNewState(PowerUpState.available);
        }
        
        private int level=0;
        public void LevelUpgrade()
        {
            if (state == PowerUpState.available)
            {
                level++;
                if (level == 3)
                {
                    SetNewState(PowerUpState.upgraded);
                }
            }
        }
        
        public abstract void LaunchSkill();
    }
}
