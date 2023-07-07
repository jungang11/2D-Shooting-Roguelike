using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public float gameTime = 0;
    public float maxGameTime = 300;
    public TMP_Text timeText;

    private void Awake()
    {
        timeText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        StartCoroutine(TimeSetRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator TimeSetRoutine()
    {
        while (true)
        {
            gameTime += Time.deltaTime;
            if (gameTime > maxGameTime)
                gameTime = maxGameTime;

            GameManager.Data.gameTime = gameTime;

            int min = (int)gameTime / 60;
            int sec = (int)gameTime % 60;

            timeText.text = $"{min} : {sec}";

            yield return null;
        }
    }
}
