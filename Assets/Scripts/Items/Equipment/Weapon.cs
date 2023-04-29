using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс оружия
namespace Equipment
{
    public class Weapon : Equipment
    {
        private void Awake()
        {
            _type = Types.Weapon;
        }
    }
}
