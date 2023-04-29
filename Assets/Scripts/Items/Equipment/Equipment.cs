using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Базовый класс снаряжения существ
namespace Equipment
{
    public abstract class Equipment : MonoBehaviour
    {
        [SerializeField] protected Types _type;
    }
}
