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

        [Space(10)] [SerializeField] private float moduleWidth, moduleHeight;
        private Queue<GameObject> modules;

        private void InstanceFirtsModules()
        {
            modules = new Queue<GameObject>();
            modules.Enqueue(moduleBuilder.WithBase(transform, moduleWidth, moduleHeight).WithEscenary("level0")
                .WithPlatforms(2).Build());
            for (int i = 0; i < 25; i++)
            {
                InstanceModule();
            }
        }

        void FixedUpdate()
        {
            if (GameStatus.Instance.Status != Status.built)
            {
                foreach (var module in modules)
                {
                    module.transform.Translate(Vector3.left * (Time.fixedDeltaTime * velocity), Space.Self);
                }

                if (modules.Peek().transform.position.x <= moduleWidth * -2)
                {
                    modules.Dequeue().GetComponent<Module>().DeactiveParts();
                    InstanceModule();
                    passedModules++;
                }
            }
        }

        private void InstanceModule()
        {
            float lastModule = modules.Last().transform.localPosition.x;
            modules.Enqueue(moduleBuilder.WithBase(transform, moduleWidth, moduleHeight).WithEscenary("level0")
                .WithPlatforms(2).WithPickUps(5).WithHazards(0).Build());

            modules.Last().transform.localPosition = new Vector3(lastModule + moduleWidth, 0, 0);
        }
    }
}