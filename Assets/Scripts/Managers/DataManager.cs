using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public PlayerData playerData;

    public int level;
    public int kill;
    public float exp;
    public float nextExp;

    private void Awake()
    {
        playerData = GameManager.Resource.Load<PlayerData>("Data/PlayerData");
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        level = 1;
        exp = 0;
        kill = 0;
        nextExp = 10f;
    }

    public void GetExp()
    {
        exp++;

        if (exp >= nextExp)
        {
            level++;
            nextExp = level * 10f;
            exp = 0;
            GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/LevelUpUI");
        }
    }
}
