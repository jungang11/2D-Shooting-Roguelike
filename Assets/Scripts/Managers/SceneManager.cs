using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    private LoadingUI loadingUI;

    private BaseScene curScene;
    public BaseScene CurScene
    {
        get
        {
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();

            return curScene;
        }
    }

    private void Awake()
    {
        LoadingUI ui = Resources.Load<LoadingUI>("Prefab/UI/LoadingUI");
        loadingUI = Instantiate(ui);
        loadingUI.transform.SetParent(transform, false);
    }

    public void LoadScene(string sceneName)
    {
        if(GameManager.UI.popUp_Stack.Count > 0)
            GameManager.UI.ClosePopUpUI();

        StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);

        yield return new WaitForSeconds(0.5f);

        while (!oper.isDone)
        {
            loadingUI.SetProgress(Mathf.Lerp(0f, 0.5f, oper.progress));
            yield return null;
        }

        CurScene.LoadAsync();
        while (CurScene.progress < 1f)
        {
            loadingUI.SetProgress(Mathf.Lerp(0.5f, 1.0f, CurScene.progress));
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
    }
}