using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public enum Status
    {
        built,
        played,
        paused,
        stopped,
    }

    public class GameStatus : MonoBehaviour
    {
        public static GameStatus Instance { get; private set; }

        private void Awake()
        {
            //Singleton
            Instance = this;

            Built();
        }


        [SerializeField] private float transitionSpeed;

        
        private Status i_status;
        private bool inTransition;
        public Status Status => i_status;

        public delegate void NotifyStatus(Status status, bool inTransition);

        public NotifyStatus e_NewStatus;

        public void Built()
        {
            if (i_status != Status.built)
                StartCoroutine(Interpolate(1, 1, 0.02f, 0.02f, () => { ChangeStatus(Status.built); }));
        }
        
        public void Stop()
        {
            if (i_status != Status.stopped)
                StartCoroutine(Interpolate(1, 0, 0.02f, 0.0005f, () => { ChangeStatus(Status.stopped); }));
        }

        public void Pause()
        {
            if (i_status != Status.paused)
                StartCoroutine(Interpolate(1, 0, 0.02f, 0.0005f, () => { ChangeStatus(Status.paused); }));
        }

        public void Play()
        {
            if (i_status != Status.played)
            {
                StartCoroutine(Interpolate(0, 1, 0.0005f, 0.02f, () => { ChangeStatus(Status.played);  }));
            }
        }

        private void ChangeStatus(Status t_status)
        {
            i_status = t_status;
            e_NewStatus(i_status, inTransition);
        }

        private IEnumerator Interpolate(float from, float to, float fixedFrom, float fixedTo, Action callbackNotify)
        {
            //Debug.Log($"De {from} hasta {to}");
            inTransition = true;
            callbackNotify();

            Time.timeScale = from;
            Time.fixedDeltaTime = fixedFrom;
            while (Math.Abs(Time.timeScale - to) > 0.011)
            {
                //Debug.Log($"Fixed: {Time.fixedDeltaTime} * Scale: {Time.timeScale}");
                Time.timeScale = Mathf.Lerp(Time.timeScale, to, transitionSpeed * Time.fixedDeltaTime);
                Time.fixedDeltaTime = Mathf.Lerp(Time.fixedDeltaTime, fixedTo, transitionSpeed * Time.fixedDeltaTime);

                yield return null;
            }

            Time.timeScale = to;
            Time.fixedDeltaTime = fixedTo;

            inTransition = false;
            callbackNotify();
        }
    }
}