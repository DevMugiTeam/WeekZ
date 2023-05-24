using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Equipment;

namespace MobComponents
{
    public class WearManager : Component
    {
        [SerializeField] private Equipment.Types[] _items;

        private void Awake()
        {
            _items = TypesHelper.GetArmorTypesArray();
        }
    }
}
