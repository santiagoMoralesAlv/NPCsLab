using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public enum Status
    {
        stopped,
        played,
        paused,
    }
    public class GameStatus : MonoBehaviour
    {
        public static GameStatus Instance {get; private set; }
        
        private void Awake()
        {
            //Singleton
            Instance = this;
        }
        
        
        [SerializeField]
        private float transitionSpeed;

        private Status i_status;
        public Status Status => i_status;
        
        public delegate void NotifyStatus(Status status);
        public NotifyStatus e_NewStatus;

        public void Stop()
        {
            ChangeStatus(Status.stopped);
            StartCoroutine(Interpolate(0,1));
        }
        
        public void Pause()
        {
            ChangeStatus(Status.paused);
            StartCoroutine(Interpolate(1,0));
        }

        public void Play()
        {
            ChangeStatus(Status.played);
            StartCoroutine(Interpolate(0,1));
        }

        private void ChangeStatus(Status t_status)
        {
            i_status = t_status;
            e_NewStatus(i_status);
        }

        private IEnumerator Interpolate(float from, float to)
        {
            Time.timeScale = from;
            while (Math.Abs(Time.timeScale - to) > 0.001)
            {
                Time.timeScale = Mathf.MoveTowards(Time.timeScale,to, transitionSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
