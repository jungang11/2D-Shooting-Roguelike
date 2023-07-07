using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["CancelButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["ExitButton"].onClick.AddListener(() => { Application.Quit(); });
    }
}
