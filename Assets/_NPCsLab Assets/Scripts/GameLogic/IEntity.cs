using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IEntity
    {

        GameObject DeadEffect
        {
            get;
        }
        
        GameObject WakeUpEffect
        {
            get;
        }


    }
}
