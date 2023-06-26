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
        yield return null;
    }
}