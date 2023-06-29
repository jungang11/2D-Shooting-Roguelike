using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public TMP_Text killCountText;

    private void OnEnable()
    {
        StartCoroutine(SetKillCountRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SetKillCountRoutine()
    {
        while (true)
        {
            int kill = GameManager.Data.currentPlayerData.kill;

            killCountText.text = $"{kill}";

            yield return null;
        }
    }
}
