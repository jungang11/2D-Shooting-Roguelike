using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public PlayerData basePlayerData;
    public PlayerData currentPlayerData;

    private void Awake()
    {
        // 원본 Scriptabel Object
        basePlayerData = GameManager.Resource.Load<PlayerData>("Data/PlayerData");
        // Scriptable Object Clone 사용
        currentPlayerData = GameManager.Resource.Instantiate<PlayerData>("Data/PlayerData", transform);
    }

    public void GetExp()
    {
        currentPlayerData.exp += 1 * currentPlayerData.expMultiplier;

        if (currentPlayerData.exp >= currentPlayerData.nextExp)
        {
            currentPlayerData.level++;
            currentPlayerData.nextExp = currentPlayerData.level * 3f;
            currentPlayerData.exp = 0;
            GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/LevelUpUI");
        }
    }
}
