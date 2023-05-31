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
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(States))]
    [RequireComponent(typeof(AnimationController))]
    public abstract class Mob : MonoBehaviour
    {
        [SerializeField] protected States _states;
        internal Movement _movement;
        protected AnimationController _anim;

        [SerializeField] protected bool _invulnerability;// Неуязвимость (нельзя получить урон)
        [SerializeField] protected bool _immotality;// Бессмертие (можно получить урон, но не умереть)
        [SerializeField] protected bool _inDash;// В кувырке
 
        [SerializeField] protected Fraction _fraction;
        [SerializeField] protected Fraction[] _enemies;
        [SerializeField] protected Fraction[] _allies;

        [SerializeField] protected Inventory _inventory;
        [SerializeField] protected WearManager _wearManager;
        [SerializeField] protected WeaponManager _weaponManager;

        public Action<int> changeHp;
        internal Action<bool> invulnerability;
        internal Action<bool> inDash;

        private void Awake()
        {
            _states = GetComponent<States>();
            _movement = GetComponent<Movement>();
            _anim = GetComponent<AnimationController>();
            _inventory = GetComponent<Inventory>();
        }

        private void Start()
        {
            _movement.SetMob(this);
            _anim.SetMob(this);
            _wearManager.SetMob(this);
        }

        private void OnEnable()
        {
            changeHp += ChangeHp;
            invulnerability += SetInvulnerability;
            inDash += SetInDash;
        }

        private void OnDisable()
        {
            changeHp -= ChangeHp;
            invulnerability -= SetInvulnerability;
            inDash -= SetInDash;
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

        private bool PickItem(Equipment.Equipment item)
        {
            return _inventory.AddEquipment(item);
        }

        public int Speed { get { return _states.speed; } }

        public int SpeedRun { get { return _states.speed_run; } }

        public bool Invulnerability { get { return _invulnerability; } }

        public bool InDash {  get { return _inDash; } }

        private void SetInvulnerability(bool input)
        {
            _invulnerability = input;
        }

        private void SetInDash(bool input)
        {
            _inDash = input;
        }
    }
}
