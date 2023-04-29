using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс-родитель всех живых существ в игре
namespace Mobs {
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(MobComponents.Movement))]
    public abstract class Mob : MonoBehaviour
    {
        [SerializeField] protected int _hp;
        [SerializeField] protected int _hpMax;
        [SerializeField] protected int _speed;

        [SerializeField] protected bool _invulnerability;
        [SerializeField] protected bool _immotality;

        [SerializeField] protected Fraction _fraction;
        [SerializeField] protected Fraction[] _enemies;
        [SerializeField] protected Fraction[] _allies;

        public Action<int> changeHp;
        internal Action<Vector2> readMovement;

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
            if(input < 0)
            {
                if (_invulnerability) return;
                else
                {
                    _hp += input;
                    if(_hp <= 0)
                    {
                        if(_immotality)
                        {
                            _hp = 1;
                        }
                        else
                        {
                            _hp = 0;
                            Die();
                        }
                    }
                }
            }
            else
            {
                _hp += input;
                if(_hp > _hpMax)
                {
                    _hp = _hpMax;
                }
            }
        }

        private void Die()
        {

        }

        public int Speed { get { return _speed; }  }
    }
}
