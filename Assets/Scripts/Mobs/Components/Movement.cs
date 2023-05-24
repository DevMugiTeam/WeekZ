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
        private int _speedCurrent;
        private Vector2 _moveVector;

        private Rigidbody2D _rb;

        internal Action<Vector2> readMovement;
        internal Action idle;
        internal Action move;
        internal Action dash;

        private void Awake()
        {
            _rb =  GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _speedCurrent = _mob.Speed;
        }

        private void OnEnable()
        {
            readMovement += ReadMovement;
            dash += Dash;
        }

        private void OnDisable()
        {
            readMovement -= ReadMovement;
            dash -= Dash;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (_mob.inDash) return;
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

        private void Dash()
        {
            if(_mob.inDash || _moveVector.magnitude == 0) return;
            _mob.inDash = true;
            _rb.velocity = _moveVector * _dashPower;
            dash?.Invoke();
        }

        private void ReadMovement(Vector2 input)
        {
            _moveVector = input.normalized;
        }
    }
}
