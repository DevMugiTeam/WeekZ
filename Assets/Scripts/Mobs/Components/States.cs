using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Параметры существ
namespace MobComponents
{
    public class States : MonoBehaviour
    {
        public int hp;
        public int hp_Max;
        public int sp;
        public int sp_Max;
        public int xp;
        public int xp_Max;
        public int level;

        public int speed;

        public int defense;

        public int satiety;
        public int thirst;
        public int satiety_expend;
        public int thirst_expend;
    }
}