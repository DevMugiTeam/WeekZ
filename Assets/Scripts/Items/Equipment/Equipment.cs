using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// ������� ����� ���������� �������
namespace Equipment
{
    public abstract class Equipment : MonoBehaviour
    {
        [SerializeField] protected Types _type;
    }
}
