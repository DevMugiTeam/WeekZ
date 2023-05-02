using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

// Класс инвентаря
// Содержит объекты снаряжения 
namespace Equipment
{
    public class Inventory : MonoBehaviour
    {
        private Types[] _types;
        private Equipment[] _equipment;

        private void Awake()
        {
            _types = TypesHelper.GetTypesArray();
            _equipment = new Equipment[_types.Length];
        }

        public bool AddEquipment(Equipment input)
        {
            for(int i = 0; i < _types.Length; i++)
            {
                if(TypesHelper.CompareTypes(input.GetEType(), _types[i]))
                {
                    _equipment[i] = input;
                    return true;
                }
            }
            return false;
        }

        public void RemoveEquipment(Types input)
        {
            for (int i = 0; i < _types.Length; i++)
            {
                if (TypesHelper.CompareTypes(input, _types[i]))
                {
                    _equipment[i] = null;
                    return;
                }
            }
        }

        public Equipment GetEquipment(Types input)
        {
            for (int i = 0; i < _types.Length; i++)
            {
                if (TypesHelper.CompareTypes(input, _types[i]))
                {
                    return _equipment[i];
                }
            }
            return null;
        }
    
    }
}
