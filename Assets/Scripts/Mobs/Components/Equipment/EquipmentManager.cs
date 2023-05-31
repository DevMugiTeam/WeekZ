using Equipment;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEditor.Progress;

namespace MobComponents
{
    // Класс, управляющий отображающейся экипировкой существ
    public abstract class EquipmentManager : Component
    {

        //Список экипировки
        [SerializeField] protected List<Equipment.Equipment> _equipmentList;

        //Переменная, хранящая типы надетой экипировки
        [SerializeField] protected int _equipped;

        private void Awake()
        {
            if(_equipmentList == null) _equipmentList = new();
        }

        private void Start()
        {
            UpdateEquippedEquipment();
            if(_equipmentList.Count > 0)
            {
                foreach (Equipment.Equipment e in _equipmentList)
                {
                    e.SetMob(_mob);
                    Init(e);      
                }
            }
        }

        protected void UpdateEquippedEquipment()
        {
            _equipped = 0;
            foreach (Equipment.Equipment e in _equipmentList)
            {
                _equipped |= (int)e.GetEType();
            }
        }

        //Добавление в список экипировки
        internal virtual bool Add(Equipment.Equipment input)
        {
            if (IsEquipped(input)) return false;
            _equipmentList.Add(Init(input));
            _equipped |= (int)input.GetEType();
            return true;
        }

        //Инициализация игрового обьекта
        protected Equipment.Equipment Init(Equipment.Equipment input)
        {
            Equipment.Equipment e = Instantiate(input, transform.position, transform.rotation);
            e.gameObject.transform.SetParent(transform);
            e.SetMob(_mob);
            return e;
        }

        //Удаление из списка экипировки
        internal virtual bool Remove(Equipment.Equipment input)
        {
            if( _equipmentList.Remove(input))
            {
                input.RemoveMob();
                _equipped ^= (int)input.GetEType();
                return true;
            }
            return false;
        }

        //Проверка на возможность добавления экипировки
        protected bool IsEquipped(Equipment.Equipment input)
        {
            return ((int)input.GetEType() & _equipped) > 0;
        }
    }
}
