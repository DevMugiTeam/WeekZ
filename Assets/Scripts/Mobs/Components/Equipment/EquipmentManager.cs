using Equipment;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEditor.Progress;

namespace MobComponents
{
    // �����, ����������� �������������� ����������� �������
    public abstract class EquipmentManager : Component
    {

        //������ ����������
        [SerializeField] protected List<Equipment.Equipment> _equipmentList;

        //����������, �������� ���� ������� ����������
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

        //���������� � ������ ����������
        internal virtual bool Add(Equipment.Equipment input)
        {
            if (IsEquipped(input)) return false;
            _equipmentList.Add(Init(input));
            _equipped |= (int)input.GetEType();
            return true;
        }

        //������������� �������� �������
        protected Equipment.Equipment Init(Equipment.Equipment input)
        {
            Equipment.Equipment e = Instantiate(input, transform.position, transform.rotation);
            e.gameObject.transform.SetParent(transform);
            e.SetMob(_mob);
            return e;
        }

        //�������� �� ������ ����������
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

        //�������� �� ����������� ���������� ����������
        protected bool IsEquipped(Equipment.Equipment input)
        {
            return ((int)input.GetEType() & _equipped) > 0;
        }
    }
}
