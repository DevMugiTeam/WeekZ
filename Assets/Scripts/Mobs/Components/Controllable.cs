using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс определяет поведение существа
namespace MobComponents
{
    public class Controllable : Component
    {
        private Mobs.Character _character;

        private void Awake()
        {
            _character = GetComponent<Mobs.Character>();    
        }

        public void ReadMovement(Vector2 input)
        {
            _character._movement.readMovement(input);
        }

        public void Dash()
        {
            _character._movement.Dash();
        }

        public void Run(bool input)
        {
            _character._movement.RunPressed(input);
        }
    }
}

