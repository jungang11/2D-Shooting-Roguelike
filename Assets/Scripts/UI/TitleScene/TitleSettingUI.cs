using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSettingUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["CheckButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
    }
}
