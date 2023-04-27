using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

// Класс, отвечающий за передвижение обьектов
// Конролируется классом Mob
namespace MobComponents
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        private int _speedCurrent;
        private Vector2 _moveVector;
        private Rigidbody2D _rb;
        private Mobs.Mob _mob;        

        private void Awake()
        {
            _rb =  GetComponent<Rigidbody2D>();
            _mob = GetComponent<Mobs.Mob>();
            _speedCurrent = _mob.Speed;
        }

        private void OnEnable()
        {
            _mob.readMovement += ReadMovement;
        }

        private void OnDisable()
        {
            _mob.readMovement -= ReadMovement;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rb.velocity = _moveVector * _speedCurrent;
        }

        private void ReadMovement(Vector2 input)
        {
            _moveVector = input;
        }
    }
}
