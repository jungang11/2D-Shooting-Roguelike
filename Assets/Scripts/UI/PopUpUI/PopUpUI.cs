using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : BaseUI
{
    protected PlayerData playerData;

    protected override void Awake()
    {
        base.Awake();

        playerData = GameManager.Data.currentPlayerData;
    }
}
