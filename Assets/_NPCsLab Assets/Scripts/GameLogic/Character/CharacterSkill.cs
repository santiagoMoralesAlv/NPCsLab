using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Characters
{
    public enum CharacterSkillState
    {
        available,
        inCooldown,
        active
    }

    public abstract class CharacterSkill : MonoBehaviour, Skill
    {
        public event NotifyState e_NewState;

        private CharacterSkillState state;
        public CharacterSkillState State => state;

        protected Animator _animator;
        public Animator Animator => _animator;

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
        }

        protected void SetNewState(CharacterSkillState newState)
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
            currentCooldown = 0;
            SetNewState(CharacterSkillState.available);
        }

        public void LevelUpgrade()
        {
            //Por el momento no se ha hablado de subir de nivel estas habilidades, es solo una idea
            //por lo tanto de ser el caso va aqui, de no ser asi se borra
        }

        public abstract void LaunchSkill();


        private float currentCooldown;
        private float cooldownMaxTime;

        protected void Update()
        {
            if (state == CharacterSkillState.inCooldown)
            {
                if (currentCooldown >= cooldownMaxTime)
                {
                    currentCooldown = 0;
                    SetNewState(CharacterSkillState.available);
                }
                else
                {
                    currentCooldown+= Time.deltaTime;
                }
            }
        }
    }
}