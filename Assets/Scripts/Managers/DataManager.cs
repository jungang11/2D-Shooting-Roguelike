using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public PlayerData basePlayerData;
    public PlayerData currentPlayerData;

    public ItemData swordData;
    public ItemData bulletData;
    public ItemData electricityData;
    public ItemData explosionData;
    public ItemData fireData;

    private void Awake()
    {
        // 원본 Scriptabel Object
        basePlayerData = GameManager.Resource.Load<PlayerData>("Data/PlayerData");
        // Scriptable Object Clone 사용
        currentPlayerData = GameManager.Resource.Instantiate<PlayerData>("Data/PlayerData", transform);

        swordData = GameManager.Resource.Instantiate<ItemData>("Data/NormalSword", transform);
        bulletData = GameManager.Resource.Instantiate<ItemData>("Data/Bullet", transform);
        electricityData = GameManager.Resource.Instantiate<ItemData>("Data/Electricity", transform);
        explosionData = GameManager.Resource.Instantiate<ItemData>("Data/Explosion", transform);
        fireData = GameManager.Resource.Instantiate<ItemData>("Data/Fire", transform);
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
