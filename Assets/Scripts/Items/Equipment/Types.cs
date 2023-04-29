using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Типы снаряжения
// Armor - вся одежда
// Weapon - все оружие
namespace Equipment { 
    public enum Types 
    {
        Face = 1 << 0,
        Head = 1 << 1,
        Body = 1 << 2,
        Hands = 1 << 3,
        Legs = 1 << 4,
        Feats = 1 << 5,
        Backpack = 1 << 6,
        W_First = 1 << 7,
        W_Secondary = 1 << 8,
        W_Melee = 1 << 9,
        W_Throwing = 1 << 10,
        Armor = Face | Head | Body | Hands | Legs | Feats | Backpack,
        Weapon = W_First | W_Secondary | W_Melee | W_Throwing
    }
}
