using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["SaveButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["CancelButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
    }
}
