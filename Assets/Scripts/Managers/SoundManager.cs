using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgmSound;
    public AudioClip[] bgmList;

    public BaseScene curScene;

    private void Start()
    {
        StartCoroutine(SoundSettingRoutine());
        Init();
    }

    public void Init()
    {
        StartCoroutine(OnSceneLoadedBGMRoutine());
    }

    private IEnumerator OnSceneLoadedBGMRoutine()
    {
        curScene = GameManager.Scene.CurScene;

        for (int i = 0; i < bgmList.Length; i++)
        {
            if (curScene.name == bgmList[i].name)
            {
                BgmSoundPlay(bgmList[i]);

                break;
            }
        }
        yield return null;
    }

    public void BgmSoundPlay(AudioClip clip)
    {
        bgmSound.clip = clip;
        bgmSound.loop = true;
        bgmSound.volume = 0.2f;
        bgmSound.Play();
    }

    public IEnumerator SoundSettingRoutine()
    {
        while (true)
        {
            if (GameManager.Data.isMute)
                bgmSound.volume = 0f;
            else
            {
                bgmSound.volume = GameManager.Data.volume;
            }
            yield return null;
        }
    }
}
