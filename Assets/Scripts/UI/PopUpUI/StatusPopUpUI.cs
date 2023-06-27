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
        texts["LevelText"].text = GameManager.Data.level.ToString();
        texts["DamageText"].text = GameManager.Data.playerData.attack.ToString();
        texts["SpeedText"].text = GameManager.Data.playerData.movementSpeed.ToString();
        texts["KillsText"].text = GameManager.Data.kill.ToString();
        // texts["TimeText"].text = GameManager.Data.level.ToString();

        yield return null;
    }
}
