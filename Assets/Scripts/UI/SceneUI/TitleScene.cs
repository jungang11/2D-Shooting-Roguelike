using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : BaseScene
{
    public void StartButton()
    {
        GameManager.Scene.LoadScene("GameScene");
    }

    protected override IEnumerator LoadingRoutine()
    {
        progress = 0.1f;
        GameManager.Sound.Init();
        yield return new WaitForSeconds(0.3f);

        progress = 1.0f;
    }
}