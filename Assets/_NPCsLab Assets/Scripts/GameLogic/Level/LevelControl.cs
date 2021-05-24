using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using GameLogic.Characters;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = System.Random;

namespace GameLogic.Levels
{
    public class LevelControl : MonoBehaviour
    {
        // <summary> Singleton </summary>
        private static LevelControl instance;
        public static LevelControl Instance => instance;

        [SerializeField] private ModuleBuilder moduleBuilder;

        [SerializeField] private float velocity, timeRunning;
        [SerializeField] private int numOfModulesInGame;
        static private float passedModules, maxPassedModules;
        private int coins;
        public float PassedModules => passedModules;
        public float MaxPassedModules => maxPassedModules;
        public float TimeRunning => timeRunning;
        public float Coins => coins;

        public bool UseCoins(int coinsToUse)
        {
            if ((coins - coinsToUse) >= 0)
            {
                coins -= coinsToUse;
                return true;
            }

            return false;
        }
        
        [SerializeField] private Transform centerPoint;

        public Transform CenterPoint => centerPoint;

        private void Awake()
        {
            //Singleton initialization
            instance = this;

            
            moduleBuilder.Init();
            
            GameStatus.Instance.e_NewStatus += CheckGameStatus;
            
            
            theFirtsTime = false;
        }

        private void Start()
        {
            modules = new Queue<Module>();
            LevelControl.Instance.InstanceSpecificModule("base");
            if (PlayerPrefs.GetInt("TutorialHasPlayed", 0) <= 0)
            {
                LevelControl.Instance.InstanceSpecificModule("tutorial1");
                LevelControl.Instance.InstanceSpecificModule("tutorial");
                LevelControl.Instance.InstanceSpecificModule("tutorial2");
                LevelControl.Instance.InstanceSpecificModule("tutorial2");
                LevelControl.Instance.InstanceSpecificModule("tutorial");
                LevelControl.Instance.InstanceSpecificModule("tutorial");
            }

        }

        private bool theFirtsTime;
        [SerializeField] private AudioSource music;
        [SerializeField] private AudioClip[] songs;
        public void CheckGameStatus(Status _status, bool inTransition)
        {
            if (_status == Status.played && inTransition)
            {
                if (!theFirtsTime)
                {
                    passedModules = 0;
                    coins = 0;
                    timeRunning = 0;

                    Character.Instance.WakeUp();
                    InstanceFirtsModules();
                    
                    music.clip = songs[UnityEngine.Random.Range(0,songs.Length-1)];
                    music.Play();

                    theFirtsTime = true;
                }
                else
                {
                    music.clip = songs[UnityEngine.Random.Range(0,songs.Length-1)];
                    music.Play();
                }

            }
        }

        void Update()
        {
            if (GameStatus.Instance.Status == Status.played)
            {
                timeRunning += Time.deltaTime;
            }

            if (timeRunning > maxPassedModules)
            {
                maxPassedModules = timeRunning;
            }
        }

        private Queue<Module> modules;

        public void CollectCoin()
        {
            coins++;
        }
        
        

        void FixedUpdate()
        {
            if ((GameStatus.Instance.Status == Status.played || GameStatus.Instance.Status == Status.paused) && Character.Instance.IsAlive)
            {
                foreach (var module in modules)
                {
                    if (timeRunning > 0 && Time.timeScale>0)
                    {
                        module.transform.Translate(
                            Vector3.left * (Time.fixedDeltaTime * (Mathf.Log(velocity * timeRunning * Time.timeScale))), Space.Self);
                    }
                }

                if (modules.Peek().transform.position.x <= -modules.Peek().WidthSize)
                {
                    modules.Dequeue().DeactiveParts();
                    InstanceRandomModule();
                    passedModules++;
                }
            }
        }

        public Action EInit;
        private void InstanceFirtsModules()
        {
            (EInit)?.Invoke();
            for (int i = 0; i < numOfModulesInGame; i++)
            {
                InstanceRandomModule();
            }
        }

        public void InstanceSpecificModule(string moduleName)
        {
            modules.Enqueue(moduleBuilder.WithCompletedModule(moduleName, transform, GetLastModule()).Build());
        }
        
        private void InstanceRandomModule()
        {
            modules.Enqueue(moduleBuilder.WithCompletedModule(transform, GetLastModule()).Build());
        }

        private ModuleTransform GetLastModule()
        {
            if (modules.Count == 0)
            {
                return new NullModule();
            }
            else
            {
                return modules.Last();
            }
        }
    }
}