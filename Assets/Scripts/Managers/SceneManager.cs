using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    public LoadingUI loadingUI;

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
        loadingUI = GameManager.Resource.Instantiate<LoadingUI>("Prefab/UI/LoadingUI");

        GameManager.Pool.Get(loadingUI);
        loadingUI.transform.SetParent(GameManager.UI.canvasRoot.transform, false);
        loadingUI.gameObject.SetActive(false);
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

        loadingUI.gameObject.SetActive(true);
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

        loadingUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
}