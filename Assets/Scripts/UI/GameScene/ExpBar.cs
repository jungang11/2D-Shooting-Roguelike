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

    private void OnEnable()
    {
        StartCoroutine(SetValueRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SetValueRoutine()
    {
        while (true)
        {
            float curExp = GameManager.Data.exp / GameManager.Data.nextExp[GameManager.Data.level];
            slider.value = curExp;
            yield return null;
        }
    }
}
