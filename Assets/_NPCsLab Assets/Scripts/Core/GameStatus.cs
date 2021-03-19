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
        public static GameStatus Instance { get; private set; }

        private void Awake()
        {
            //Singleton
            Instance = this;
        }


        [SerializeField] private float transitionSpeed;

        private Status i_status;
        public Status Status => i_status;

        public delegate void NotifyStatus(Status status);

        public NotifyStatus e_NewStatus;

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
                StartCoroutine(Interpolate(0, 1, 0.0005f, 0.02f, () => { ChangeStatus(Status.played); }));
            }
        }

        private void ChangeStatus(Status t_status)
        {
            i_status = t_status;
            e_NewStatus(i_status);
        }

        private IEnumerator Interpolate(float from, float to, float fixedFrom, float fixedTo, Action callback)
        {
            Debug.Log($"De {from} hasta {to}");
            callback();

            //Time.fixedDeltaTime=0.0005f;
            Time.timeScale = from;
            Time.fixedDeltaTime = fixedFrom;
            while (Math.Abs(Time.timeScale - to) > 0.011)
            {
                Debug.Log($"Fixed: {Time.fixedDeltaTime} * Scale: {Time.timeScale}");
                Time.timeScale = Mathf.Lerp(Time.timeScale, to, transitionSpeed * Time.fixedDeltaTime);
                Time.fixedDeltaTime = Mathf.Lerp(Time.fixedDeltaTime, fixedTo, transitionSpeed * Time.fixedDeltaTime);
                // Time.timeScale = Mathf.MoveTowards(Time.timeScale, to, transitionSpeed * Time.fixedDeltaTime);

                yield return null;
            }

            Time.timeScale = to;
            Time.fixedDeltaTime = fixedTo;

            //Time.fixedDeltaTime=0.02f;
        }
    }
}