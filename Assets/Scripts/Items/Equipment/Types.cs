using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

// Типы снаряжения
// Armor - вся одежда
// Weapon - все оружие
namespace Equipment
{
    public abstract class TypesHelper
    {
        public static Array GetAllTypes()
        {
            return Enum.GetValues(typeof(Types));
        }

        public static Types[] GetTypesArray()
        {
            return (Types[])Enum.GetValues(typeof(Types));
        }

        public static Types[] GetAllTypes(Predicate<Types> predicate)
        {
            List<Types> array = new List<Types>();
            array.AddRange(GetAllTypes());
            array.RemoveAll(predicate);
            return array.ToArray();
        }

        public static bool CompareTypes(Types input1, Types input2)
        {
            return input1 == input2;
        }

        public static bool CheckSimilarTypes(Types input1, Types input2)
        {
            return (input1 & input2) > 0;
        }
    }

    public enum Types
    {
        Null = 0,
        Face = 1 << 0,
        Head = 1 << 1,
        Body = 1 << 2,
        Overdress = 1 << 3,
        //Palms = 1 << 4,
        Legs = 1 << 5,
        Feet = 1 << 6,
        Backpack = 1 << 7,
        W_First = 1 << 8,
        W_Secondary = 1 << 9,
        W_Melee = 1 << 10,
        W_Throwing = 1 << 11,
        Armor = Face | Head | Body | Overdress /*| Palms*/ | Legs | Feet | Backpack,
        Weapon = W_First | W_Secondary | W_Melee | W_Throwing
    }
}
