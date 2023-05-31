using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using MobComponents;
using Mobs;

// Базовый класс снаряжения существ
namespace Equipment
{
    [RequireComponent(typeof(AnimationController))]
    public abstract class Equipment : MonoBehaviour
    {

        [SerializeField] protected Types _type;
        [SerializeField] protected AnimationController _anim;
        [SerializeField] protected Mob _mob;

        private void Awake()
        {
            _anim = GetComponent<AnimationController>();
        }

        private void OnEnable()
        {
            _anim.enabled = true;
        }

        public Types GetEType() { return _type; }

        internal void SetMob(Mob input) 
        {
            if (input == null) { return; }
            _mob = input;
            _anim.SetMob(input);
            _anim.Sub();
        }

        internal void RemoveMob()
        {
            _mob = null;
            _anim.UnSub();
        }
    }
}
