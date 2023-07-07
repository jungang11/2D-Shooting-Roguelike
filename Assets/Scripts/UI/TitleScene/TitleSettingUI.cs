using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSettingUI : PopUpUI
{
    public Slider soundSlider;
    public Toggle muteToggle;
    public Toggle printDamageToggle;

    protected override void Awake()
    {
        base.Awake();

        soundSlider = GetComponentInChildren<Slider>();
        printDamageToggle = GetComponentsInChildren<Toggle>()[0];
        muteToggle = GetComponentsInChildren<Toggle>()[1];

        buttons["CheckButton"].onClick.AddListener(() => { OptionCheckButton(); });
    }

    public void OptionCheckButton()
    {
        GameManager.Data.volume = soundSlider.value;
        GameManager.Data.isMute = muteToggle.isOn;
        GameManager.Data.isPrintDamage = printDamageToggle.isOn;

        GameManager.UI.ClosePopUpUI();
    }
}
