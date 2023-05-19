using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static Action OnMinuteChange;
    public static Action OnHourChange;


    public static int _minute { get; private set; }
    public static int _hour { get; private set; }

    [SerializeField] private float minuteToRealtime;
    private float _timer;




    void Start()
    {
        _minute = 0;
        _hour = 10;
        _timer = minuteToRealtime;
    }


    void Update()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0)
        {
            _minute++;
            OnMinuteChange?.Invoke();
            if(_minute >= 60)
            {
                _minute = 0;
                _hour++;
                OnHourChange?.Invoke();
                if(_hour >= 24)
                {
                    _hour = 0;
                    //day++;
                    //здесь будем прибавлять прошедшие дни когда понадобиться
                }
            }

            _timer = minuteToRealtime;

        }


    }


}
