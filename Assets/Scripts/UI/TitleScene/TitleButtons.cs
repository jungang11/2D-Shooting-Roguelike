using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtons : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["PowerUpButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/PowerUpPopUpUI"); });
        buttons["ConfigButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/TitleSettingPopUp"); });
        buttons["ExitButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/ExitPopUpUI"); });
    }
}
