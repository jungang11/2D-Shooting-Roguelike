using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int currentLevel { get; private set; }
    public ItemData currentWeaponData { get; private set; }
    public WeaponStats currentWeaponStats;

    protected virtual void Awake()
    {
        //Init();
    }

    /*private void Init()
    {
        currentWeaponData = GameManager.Resource.Load<ItemData>("Item");
        currentWeaponStats = new WeaponStats();
        SetLevel(0);
    }

    private void SetLevel(int level)
    {
        currentLevel = Mathf.Clamp(level, 0, currentWeaponData.Items[0].levelData.Length - 1);
        currentWeaponStats.UpdateStats(currentWeaponData.Items[0].levelData[currentLevel]);
    }

    public virtual void SetLevelUp()
    {
        SetLevel(++currentLevel);
    }*/
}