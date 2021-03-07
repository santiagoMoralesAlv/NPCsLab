using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Characters;
using UnityEngine;


namespace GameLogic.Characters
{
    public class StateObserver : StateMachineBehaviour
    {
        // <summary>Reference to the entity</summary>
        private Character m_character;

        //<summary>Group of the states that will be notify to the entity</summary>
        [SerializeField] private string[] states = new string[]
            {"WakeUp", "Die"};

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            //Make the entity reference
            if (m_character == null)
            {
                m_character = animator.gameObject.GetComponent<Character>();
            }


            //Search each state and compare the states array, if it find ones, then, notify
            foreach (var state in states)
            {
                if (Animator.StringToHash(state) == stateInfo.shortNameHash) //NameHash is the only way to identify the animator state
                {
                    try
                    {
                        m_character.SetNewState(state); //change the state, the entity will notify its state
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }
        
    }
}