using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace GameLogic.Characters
{
    public class Character : MonoBehaviour, IEntity
    {
        #region Basic

        // <summary> Singleton </summary>
        private static Character instance;
        
        public static Character Instance => instance;
        private Animator m_animator;
        private Rigidbody2D m_rg;
        [SerializeField] GameObject shieldPlayer;



        private void Awake()
        {
            //Singleton initialization
            instance = this;
            m_animator = this.GetComponent<Animator>();
            m_rg = this.GetComponent<Rigidbody2D>();
            m_rg.simulated = false;
        }

        #endregion

        #region States
        public NotifyState e_NewState, e_OldState;

        private string currentState;
        public string CurrentState => currentState;


        /// <summary>
        /// Allow change the state and notify with a event. It method is called by the StateMachineBehavior of the animator
        /// </summary>
        /// <param name="newState">new state</param>
        public virtual void SetNewState(string state)
        {
            if (state != "")
            {
                try
                {
                    e_OldState(currentState);
                }
                catch (Exception e)
                {
                    //Without subscriptions
                }
            }

            currentState = state;
            try
            {
                e_NewState(currentState);
            }
            catch (Exception e)
            {
                //Without subscriptions
            }

            switch (state) //behavior demanded by the animator
            {
                default:

                    break;
            }
        }
        #endregion

        #region Components
        private CharacterMov _characterMov;
        private CharacterSkill _characterSkill;
        private PowerUpSkill _powerUp;

        public CharacterMov CharacterMov
        {
            get => _characterMov;
            set => _characterMov = value;
        }

        public CharacterSkill CharacterSkill
        {
            get => _characterSkill;
            set => _characterSkill = value;
        }

        public PowerUpSkill PowerUp
        {
            get => _powerUp;
            set => _powerUp = value;
        }
        #endregion

        #region basicFuntions

        private bool isAlive;
       
        public bool IsAlive => isAlive;

        public void ShieldActive()
        {
            shieldPlayer.SetActive(true);
        }

        public void WakeUp()
        {
            m_animator = this.GetComponent<Animator>();
            isAlive = true;
            m_rg.simulated = true;
            this.GetComponent<AudioSource>().Play();

            m_animator.SetTrigger("WakeUp"); //Notify a new state transition
        }
        public void Kill()
        {   
            isAlive = false;                
            m_rg.simulated = false;
            m_animator.SetTrigger("Dead"); //Notify a new state transition
            Destroy(this.gameObject, .3f);
            GameStatus.Instance.Stop();
        }   
        #endregion
    }
}