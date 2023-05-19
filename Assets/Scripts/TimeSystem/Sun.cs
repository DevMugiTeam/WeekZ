using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private float _sunriseTime; //����� ������� ������
    [SerializeField] private float _sunsetTime; //����� ������ ������
    [SerializeField] private SpriteRenderer _sun; //������(������)


    [SerializeField] private Color _sunriseColor;
    [SerializeField] private Color _sunsetColor;



    private void OnEnable()
    {
        TimeController.OnHourChange+= TimeCheck;
    }

    private void OnDisable()
    {
        TimeController.OnHourChange -= TimeCheck;
    }


    private void Update()
    {
        
    }

    private void TimeCheck()
    {
        if(TimeController._hour == _sunriseTime)
        {
            Debug.Log("������");
            _sun.color = _sunriseColor;
        }
        if(TimeController._hour == _sunsetTime)
        {
            Debug.Log("�����");
            _sun.color = _sunsetColor;
            
        }
    }
}
