using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public PlayerData currentPlayerData;
    public PlayerController playerController;

    private void Awake()
    {
        currentPlayerData = GameManager.Resource.Instantiate<PlayerData>("Data/PlayerData");

    }

    public void GetExp()
    {
        currentPlayerData.exp++;

        if (currentPlayerData.exp >= currentPlayerData.nextExp)
        {
            currentPlayerData.level++;
            currentPlayerData.nextExp = currentPlayerData.level * 10f;
            currentPlayerData.exp = 0;
            GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/LevelUpUI");
        }
    }
}
