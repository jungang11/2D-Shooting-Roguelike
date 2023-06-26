using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["PauseButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/PausePopUpUI"); });
    }
}
