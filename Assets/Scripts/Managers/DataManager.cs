using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public PlayerData basePlayerData;
    public PlayerData currentPlayerData;

    public Weapon weapon;

    public ItemData swordData;
    public ItemData bulletData;
    public ItemData electricityData;
    public ItemData explosionData;
    public ItemData fireData;

    private void Awake()
    {
        // 원본 Scriptabel Object
        basePlayerData = GameManager.Resource.Load<PlayerData>("Data/PlayerData");

        Init();
    }

    public void Init()
    {
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

    #region WeaponLevelUP
    public void SwordLevelUP()
    {
        swordData.Items[0].currentLevel++;
        swordData.Items[0].damage += swordData.Items[0].damages[swordData.Items[0].currentLevel];
        swordData.Items[0].count += swordData.Items[0].counts[swordData.Items[0].currentLevel];
    }

    public void BulletLevelUP()
    {
        bulletData.Items[0].currentLevel++;
        bulletData.Items[0].damage += bulletData.Items[0].damages[bulletData.Items[0].currentLevel];
    }

    public void ElectricityLevelUP()
    {
        electricityData.Items[0].currentLevel++;
        electricityData.Items[0].damage += electricityData.Items[0].damages[electricityData.Items[0].currentLevel];
    }

    public void ExplosionLevelUP()
    {
        explosionData.Items[0].currentLevel++;
        explosionData.Items[0].damage += explosionData.Items[0].damages[explosionData.Items[0].currentLevel];
    }

    public void FireLevelUP()
    {
        fireData.Items[0].currentLevel++;
        fireData.Items[0].damage += fireData.Items[0].damages[fireData.Items[0].currentLevel];
    }
    #endregion

    #region Passive
    public void ArmorLevelUP()
    {
        currentPlayerData.armor += 0.5f;
    }

    public void MovementSpeedLevelUP()
    {
        currentPlayerData.movementSpeed += 1f;
    }

    public void DamageLevelUP()
    {
        currentPlayerData.damage += 0.5f;
    }
    #endregion
}
