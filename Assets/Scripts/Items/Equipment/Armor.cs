using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

// ����� ������
namespace Equipment
{
    public class Armor : Equipment
    {

        private void Awake()
        {
            _type = Types.Armor;
        }
    }
}
