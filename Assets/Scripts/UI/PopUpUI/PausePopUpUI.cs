using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["ContinueButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["OptionButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/TitleSettingPopUp"); });
        buttons["ExitButton"].onClick.AddListener(() => { GoTitleScene(); });
    }

    public void GoTitleScene()
    {
        GameManager.UI.ClosePopUpUI();
        GameManager.Scene.LoadScene("TitleScene");

        Time.timeScale = 1.0f;
    }
}
