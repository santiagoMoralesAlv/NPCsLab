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
        [SerializeField] private ComponentsFactory platformFac;
        
        
        private GameObject platform, pickup, hazard;

        private Module _module;

        public void Init()
        { 
            platformFac.Init();   
        }
        
        public ModuleBuilder WithCompletedModule(string platformName, Transform tf, ModuleTransform lastModule)
        {
            _module =  platformFac.InstantiateEntity(platformName, tf).GetComponent<Module>();
            
            _module.Position = lastModule.Position + lastModule.WidthSize;
            return this;
        }
        
        public ModuleBuilder WithCompletedModule(Transform tf, ModuleTransform lastModule)
        {
            _module =  platformFac.InstantiateEntity(tf).GetComponent<Module>();
            
            _module.Position = lastModule.Position + lastModule.WidthSize;
            
            return this;
        }
        
        public Module Build()
        {
            _module.ActiveParts();
            return _module;
        }

        
    }
}