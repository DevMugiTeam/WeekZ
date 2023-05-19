using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;


    private void OnEnable()
    {
        TimeController.OnHourChange += UpdateTime;
        TimeController.OnMinuteChange += UpdateTime;
    }

    private void OnDisable()
    {
        TimeController.OnHourChange += UpdateTime;
        TimeController.OnMinuteChange += UpdateTime;
    }


    private void UpdateTime()
    {
        _timeText.text = $"{TimeController._hour:00}:{TimeController._minute:00}";
    }

}
