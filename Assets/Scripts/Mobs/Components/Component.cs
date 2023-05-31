using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mobs;

namespace MobComponents
{
    public class Component : MonoBehaviour
    {
        [SerializeField] protected Mob _mob;

        internal virtual void SetMob(Mob input)
        {
            if (input == null) return;
            _mob = input;
        }
        
        internal virtual void RemoveMob()
        {
            _mob = null;
        }
    }
}
