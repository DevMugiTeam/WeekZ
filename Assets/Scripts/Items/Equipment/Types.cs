using System;

// Типы снаряжения
// Armor - вся одежда
// Weapon - все оружие
namespace Equipment
{
    public abstract class TypesHelper
    {
        public static Array GetAllTypes()
        { return Enum.GetValues(typeof(Types)); }
        
        public static Types[] GetTypesArray()
        {
            Array a = GetAllTypes();
            Types[] t = new Types[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                t[i] =(Types) (a.GetValue(i));
            }
            return t;
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
        Face = 1 << 0,
        Head = 1 << 1,
        Body = 1 << 2,
        Overdress = 1 << 3,
        Palms = 1 << 4,
        Legs = 1 << 5,
        Feats = 1 << 6,
        Backpack = 1 << 7,
        W_First = 1 << 8,
        W_Secondary = 1 << 9,
        W_Melee = 1 << 10,
        W_Throwing = 1 << 11,
        Armor = Face | Head | Body | Palms | Legs | Feats | Backpack,
        Weapon = W_First | W_Secondary | W_Melee | W_Throwing
    }
}
