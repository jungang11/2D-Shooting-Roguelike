using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = GameManager.Data.nextExp[GameManager.Data.level];
        slider.value = GameManager.Data.exp;
    }

    public void SetValue(float value)
    {
        slider.value = GameManager.Data.exp;
    }
}
