using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using GameLogic.Characters;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
        private int passedModules;
        private int coins;
        public int PassedModules => passedModules;
        public float TimeRunning => timeRunning;
        public float Coins => coins;

        private void Awake()
        {
            //Singleton initialization
            instance = this;

            coins = 0;
            moduleBuilder.Init();
            InstanceFirtsModules();
            GameStatus.Instance.e_NewStatus += CheckGameStatus;
        }

        public void CheckGameStatus(Status _status, bool inTransition)
        {
            if (_status == Status.played && inTransition)
            {
                Character.Instance.WakeUp();
            }
        }

        void Update()
        {
            if (GameStatus.Instance.Status == Status.played)
            {
                timeRunning += Time.deltaTime;
            }
        }

        private Queue<Module> modules;

        public void CollectCoin()
        {
            coins++;
        }


        void FixedUpdate()
        {
            if (GameStatus.Instance.Status != Status.built)
            {
                foreach (var module in modules)
                {
                    module.transform.Translate(Vector3.left * (Time.fixedDeltaTime * velocity), Space.Self);
                }

                if (modules.Peek().transform.position.x <= -40)
                {
                    modules.Dequeue().DeactiveParts();
                    InstanceRandomModule();
                    passedModules++;
                }
            }
        }

        private void InstanceFirtsModules()
        {
            modules = new Queue<Module>();
            InstanceSpecificModule("tutorial");
            InstanceSpecificModule("tutorial");
            for (int i = 0; i < numOfModulesInGame; i++)
            {
                InstanceRandomModule();
            }
        }

        private void InstanceSpecificModule(string moduleName)
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