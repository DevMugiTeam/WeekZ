using Mobs;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MobComponents
{
    [RequireComponent(typeof(Animator))]
    public class AnimationController : Component
    {
        private Animator _animator;

        [SerializeField]
        private string[] _animations;

        private int[] _animationsHashes;

        internal Action<string> play;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _animationsHashes = new int[_animations.Length];
            for (int i = 0; i < _animations.Length; i++)
            {
                _animationsHashes[i] = Animator.StringToHash(_animations[i]);
            }
            _animator.Play(_animationsHashes[0]);
        }

        private void OnEnable()
        {
            play += StartAnimation;

        }

        private void OnDisable()
        {
            play -= StartAnimation;          

            
        }

        private void OnDestroy()
        {
            _mob._movement.idle -= PlayAnimIdle;
            _mob._movement.move -= PlayAnimMove;
            _mob._movement.dash -= PlayAnimDash;
        }

        override internal void SetMob(Mob input)
        {
            _mob = input;

            _mob._movement.idle += PlayAnimIdle;
            _mob._movement.move += PlayAnimMove;
            _mob._movement.dash += PlayAnimDash;
        }

        private void StartAnimation(string input)
        {
            for (int i = 0; i < _animations.Length; i++)
            {
                if (_animations[i].Equals(input))
                {
                    _animator.Play(_animationsHashes[i]);
                }
            }
        }

        private void StartAnimation(int input)
        {
            if (input >= 0 && input < _animations.Length)
            {
                _animator.Play(_animationsHashes[input]);
            }
        }

        private void PlayAnimIdle()
        {
            _animator.Play(_animationsHashes[0]);
        }

        private void PlayAnimMove()
        {
            _animator.Play(_animationsHashes[1]);
        }

        private void PlayAnimDash()
        {
            _animator.Play(_animationsHashes[2]);
        }

        private void StartDash()
        {
            _mob.inDash(true);
            _mob.invulnerability(true);
        }

        private void EndDash()
        {
            _mob.inDash(false);
            _mob.invulnerability(false);
        }
    }
}