using Equipment;
using MobComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс родитель всех живых существ в игре
namespace Mobs
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(States))]
    [RequireComponent(typeof(AnimationController))]
    public abstract class Mob : MonoBehaviour
    {
        [SerializeField] protected States _states;
        internal Movement _movement;
        protected AnimationController _anim;

        [SerializeField] protected bool _invulnerability;
        [SerializeField] protected bool _immotality;
        [SerializeField] internal bool inDash;
 
        [SerializeField] protected Fraction _fraction;
        [SerializeField] protected Fraction[] _enemies;
        [SerializeField] protected Fraction[] _allies;

        [SerializeField] protected Inventory _inventory;

        public Action<int> changeHp;

        private void Awake()
        {
            _states = GetComponent<States>();
            _movement = GetComponent<Movement>();
            _anim = GetComponent<AnimationController>();
        }

        private void Start()
        {
            _movement.SetMob(this);
            _anim.SetMob(this);
        }

        private void OnEnable()
        {
            changeHp += ChangeHp;
        }

        private void OnDisable()
        {
            changeHp -= ChangeHp;
        }

        private void ChangeHp(int input)
        {
            if (input < 0)
            {
                if (_invulnerability) return;
                else
                {
                    _states.hp += input;
                    if (_states.hp <= 0)
                    {
                        if (_immotality)
                        {
                            _states.hp = 1;
                        }
                        else
                        {
                            _states.hp = 0;
                            Die();
                        }
                    }
                }
            }
            else
            {
                _states.hp += input;
                if (_states.hp > _states.hp_Max)
                {
                    _states.hp = _states.hp_Max;
                }
            }
        }

        private void Die()
        {

        }

        public int Speed { get { return _states.speed; } }
    }
}
