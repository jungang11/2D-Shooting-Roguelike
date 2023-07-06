using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["HomeButton"].onClick.AddListener(() => { HomeButtonClick(); });
        buttons["RestartButton"].onClick.AddListener(() => { RestartButtonClick(); });

        texts["KillValue"].text = $"{GameManager.Data.currentPlayerData.kill}";
        texts["CoinValue"].text = $"{GameManager.Data.currentPlayerData.kill}";
    }

    private void HomeButtonClick()
    {   
        GameManager.Scene.LoadScene("TitleScene");
        Time.timeScale = 1.0f;
    }

    private void RestartButtonClick()
    {
        GameManager.Scene.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }
}
