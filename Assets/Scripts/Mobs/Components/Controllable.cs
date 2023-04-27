using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс определяет как конртолируется существо
namespace MobComponents
{
    public class Controllable : MonoBehaviour
    {
        private Mobs.Character _character;

        private void Awake()
        {
            _character = GetComponent<Mobs.Character>();    
        }

        public void ReadMovement(Vector2 input)
        {
            _character.readMovement(input);
        }
    }
}

