using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

// Класс, отвечающий за передвижение обьектов
// Конролируется классом Mob
namespace MobComponents
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : Component
    {
        [SerializeField] private int _dashPower;
        private Vector2 _moveVector;
        private bool _runPressed;
        private int _speedCurrent;

        private Rigidbody2D _rb;

        internal Action<Vector2> readMovement;
        internal Action idle;
        internal Action move;
        internal Action dash;

        internal Action<Vector2> readMovement;
        internal Action idle;
        internal Action move;
        internal Action dash;

        private void Awake()
        {
            _rb =  GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            readMovement += ReadMovement;
        }

        private void OnDisable()
        {
            readMovement -= ReadMovement;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (_mob.InDash) return;

            if (_runPressed)
            {
                _speedCurrent = (_mob.Speed + _mob.SpeedRun);
            }
            else
            {
                _speedCurrent = _mob.Speed;
            }

            _rb.velocity = _moveVector * _speedCurrent;

            if(_moveVector.magnitude == 0)
            {
                idle?.Invoke();
            }
            else
            {
                move?.Invoke();
            }
        }

        internal void Dash()
        {
            if(_mob.InDash || _moveVector.magnitude == 0) return;
            _rb.velocity = _moveVector * (_dashPower + _speedCurrent);
            dash?.Invoke();
        }

        internal void RunPressed(bool input)
        {
            _runPressed = input;
        }

        private void ReadMovement(Vector2 input)
        {
            _moveVector = input.normalized;
        }
    }
}
