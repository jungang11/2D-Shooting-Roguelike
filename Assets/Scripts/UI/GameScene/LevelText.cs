using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    public TMP_Text levelText;

    private void OnEnable()
    {
        StartCoroutine(SetLevelRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SetLevelRoutine()
    {
        while (true)
        {
            int curlevel = GameManager.Data.currentPlayerData.level;

            levelText.text = $"Level : {curlevel}";

            yield return null;
        }
    }
}
