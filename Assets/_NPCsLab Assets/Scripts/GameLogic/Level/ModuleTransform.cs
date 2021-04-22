using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameLogic.Levels
{
    public interface ModuleTransform
    {
        float HeightSize
        {
            set;
            get;
        }

        float WidthSize
        {
            set;
            get;
        }
        
        float Position {
            set;
            get;
        }
    }
}
