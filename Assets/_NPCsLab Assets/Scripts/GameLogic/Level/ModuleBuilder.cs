using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Levels
{
    /// <summary>
    /// Allow build a module just ask for the component, the amount of this and the size
    /// </summary>
    [CreateAssetMenu(fileName = "Builder", menuName = "Configs/Module Builder", order = 1)]
    public class ModuleBuilder : ScriptableObject
    {
        private Module _module;
        private Transform moduleTf;
        [SerializeField] private ComponentsFactory moduleFactory, escenaryFac, platformFac, pickupFac, hazardFac;
        
        
        private GameObject escenary, platform, pickup, hazard;


        public void Init()
        {
            moduleFactory.Init();     
            escenaryFac.Init();
            platformFac.Init();            
            pickupFac.Init();
            hazardFac.Init();
        }
        
        public ModuleBuilder WithBase(Transform tf, float widthSize, float heightSize)
        {
            _module = moduleFactory.InstantiateEntity(tf).GetComponent<Module>();
            moduleTf = _module.GetComponent<Transform>();
            _module.WidthSize = widthSize;
            _module.HeightSize = heightSize;
            return this;
        }
        
        public ModuleBuilder WithEscenary(string levelName)
        {
            _module.Escenary = escenaryFac.InstantiateEntity(levelName, moduleTf);
            return this;
        }
        
        public ModuleBuilder WithPlatforms(string platformName)
        {
            _module.Platforms = new GameObject[1];
            _module.Platforms[0] = platformFac.InstantiateEntity(platformName, moduleTf);
            return this;
        }
        
        public ModuleBuilder WithPlatforms(int amount)
        {
            _module.Platforms = platformFac.InstantiateRandomEntitiesArray(moduleTf, _module, amount, false);
            return this;
        }
        
        public GameObject Build()
        {
            _module.ActiveParts();
            return _module.gameObject;
        }

        
    }
}