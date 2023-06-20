using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] PlayerController player;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = player.HP;
        slider.value = player.HP;
        player.OnChangedHP.AddListener(SetValue);
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }
}
