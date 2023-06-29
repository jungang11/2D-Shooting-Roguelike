using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        StartCoroutine(StatusRoutine());
    }

    IEnumerator StatusRoutine()
    {
        texts["LevelText"].text = GameManager.Data.currentPlayerData.level.ToString();
        texts["DamageText"].text = GameManager.Data.currentPlayerData.attack.ToString();
        texts["SpeedText"].text = GameManager.Data.currentPlayerData.movementSpeed.ToString();
        texts["KillsText"].text = GameManager.Data.currentPlayerData.kill.ToString();
        // texts["TimeText"].text = GameManager.Data.level.ToString();

        yield return null;
    }
}
