using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

// Класс инвентаря
// Содержит объекты снаряжения 
namespace Equipment
{
    public class Inventory : MonoBehaviour
    {

        // Занятые места для снаряжения
        private int _equipped;

        //Список снаряжения
        [SerializeField] private List<Equipment> _equipment;

        private void Awake()
        {
            _equipment = new List<Equipment>();
            _equipped = 0;
        }

        public bool AddEquipment(Equipment input)
        {
            if (IsThisEquipmentEquipped(input.GetEType())) return false;
            _equipment.Add(input);
            _equipped |= (int)input.GetEType();
            return true;
        }

        public void RemoveEquipment(Types input)
        {
            _equipment.RemoveAll(i => { return TypesHelper.CompareTypes(i.GetEType(), input); });
        }

        public Equipment GetEquipment(Types input)
        {
            int index = _equipment.FindIndex(i => { return TypesHelper.CompareTypes(i.GetEType(), input); });
            if ( index >= 0)
            {
                return _equipment[index];
            }
            else
            {
                return null;
            }
        }

        private bool IsThisEquipmentEquipped(Types input)
        {
            return ((int)input & _equipped) > 0;
        }
    
    }
}
