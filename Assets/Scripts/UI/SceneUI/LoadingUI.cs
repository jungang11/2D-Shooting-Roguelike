using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void SetProgress(float progress)
    {
        slider.value = progress;
    }
}

