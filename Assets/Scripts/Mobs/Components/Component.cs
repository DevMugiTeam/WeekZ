using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mobs;

namespace MobComponents
{
    public class Component : MonoBehaviour
    {
        protected Mob _mob;

        virtual internal void SetMob(Mob input)
        {
            _mob = input;
        }
    }
}
