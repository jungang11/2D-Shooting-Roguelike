using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPopUpUI : PopUpUI
{
    public Animator anim;

    protected override void Awake()
    {
        base.Awake();

        anim = GetComponent<Animator>();

        buttons["HomeButton"].onClick.AddListener(() => { HomeButtonClick(); });
        buttons["RestartButton"].onClick.AddListener(() => { RestartButtonClick(); });

        texts["KillValue"].text = $"{GameManager.Data.currentPlayerData.kill}";
        texts["CoinValue"].text = $"{GameManager.Data.currentPlayerData.kill}";
    }

    private void OnEnable()
    {
        anim.SetTrigger("PlayerDead");
    }

    private void HomeButtonClick()
    {
        GameManager.UI.ClosePopUpUI();
        GameManager.Scene.LoadScene("TitleScene");
        Time.timeScale = 1.0f;
    }

    private void RestartButtonClick()
    {
        GameManager.UI.ClosePopUpUI();
        GameManager.Scene.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }
}
