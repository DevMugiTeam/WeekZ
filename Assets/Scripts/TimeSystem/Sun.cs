using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private float _sunriseTime; //время восхода солнца
    [SerializeField] private float _sunsetTime; //время Захода солнца
    [SerializeField] private SpriteRenderer _sun; //солнце(пример)


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
            Debug.Log("Восход");
            _sun.color = _sunriseColor;
        }
        if(TimeController._hour == _sunsetTime)
        {
            Debug.Log("Закат");
            _sun.color = _sunsetColor;
            
        }
    }
}
