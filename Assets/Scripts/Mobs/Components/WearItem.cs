using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Equipment;

namespace MobComponents
{
    [RequireComponent(typeof(AnimationController))]
    public class WearItem : Component
    {
        private AnimationController _anim;

        [SerializeField] private Equipment.Types _wearType;
        [SerializeField] private Armor _item;

        private void Awake()
        {
            _anim = GetComponent<AnimationController>();
        }
    }
}
