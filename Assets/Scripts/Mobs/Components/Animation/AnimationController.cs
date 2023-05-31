using Mobs;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MobComponents
{
    [RequireComponent(typeof(Animator))]
    public abstract class AnimationController : Component
    {
        [SerializeField] protected Animator _animator;

        [SerializeField] protected string[] _animations;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        internal abstract void Sub();

        internal abstract void UnSub();

        protected void StartAnimation(string input)
        {
            foreach(string s in _animations)
            {
                SetBool(s, false);
            }

            for (int i = 0; i < _animations.Length; i++)
            {
                if (_animations[i].Equals(input))
                {
                    SetBool(input, true);
                }
            }
        }

        protected void SetBool(string name, bool value)
        {
            _animator.enabled = true;
            _animator.SetBool(name, value);
        }
    }
}