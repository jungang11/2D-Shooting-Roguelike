using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Item", order = 0)]
public class WeaponData : ScriptableObject
{
    public int rarity;
    public int maxAmount;
    public bool isAttachedPlayer;
    public WeaponStats[] levelData;
}

[Serializable]
public class WeaponStats
{
    public int defaultDamage;              // 기본 공격력
    public int characterDamageMultiplier;  // 플레이어 공격력 비례 데미지 계수
    public int damage;

    public int cooldown;            // 쿨타임
    public int duration;            // 지속시간
    public float interval;          // 공격 간 딜레이

    public float amount;            // 갯수
    public float knockbackPower;    // 넉백 파워
    public int size;                // 크기
    public float speed;             // 속도
    public float pierce;            // 관통 횟수

    // UpdateStats함수는 플레이어 무기가 레벨업 할 때
    // 스크립터블 오브젝트를 참조하는 것이 아닌 값을 복사해오기 위함.
    public void UpdateStats(WeaponStats weaponStats)
    {
        defaultDamage = weaponStats.defaultDamage;
        characterDamageMultiplier = weaponStats.characterDamageMultiplier;
        damage = weaponStats.damage;
        cooldown = weaponStats.cooldown;
        duration = weaponStats.duration;
        interval = weaponStats.interval;
        amount = weaponStats.amount;
        knockbackPower = weaponStats.knockbackPower;
        size = weaponStats.size;
        speed = weaponStats.speed;
        pierce = weaponStats.pierce;
    }
}

