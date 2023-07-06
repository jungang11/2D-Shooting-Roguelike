using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void SetProgress(float progress)
    {
        slider.value = progress;
    }
}

