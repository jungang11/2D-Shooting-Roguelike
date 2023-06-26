using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOptionUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["OptionButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/OptionPopUpUI"); });
    }

    
}
