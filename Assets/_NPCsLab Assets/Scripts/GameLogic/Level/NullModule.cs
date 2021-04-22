using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Levels
{
    public class NullModule : ModuleTransform
    {
        
        public float HeightSize
        {
            get => 0;
            set {}
        }

        public float WidthSize
        {
            get => 0;
            set
            {
                
            }
        }
        
        public new float Position
        {
            get => 0;
            set
            {
            }
        }
    }
}
