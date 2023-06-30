using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public int   level;                 // 레벨
    public int   kill;                  // 킬 수
    public float exp;                   // 현재 경험치
    public float nextExp;               // 다음 레벨 경험치

    public float hp;                    // 체력
    public float hpRecovery;            // 체력 회복력
    public float armor;                 // 방어력
    public float movementSpeed;         // 이동속도

    public float damage;                // 공격력
    public float criticalRate;          // 크리티컬 확률
    public float criticalMultiplier;    // 크리티컬 데미지 배율

    public float area;                  // 공격 범위
    public float projectileSpeed;       // 공격 속도 (발사체)
    public float duration;              // 공격 지속시간 (원거리)
    public float coolTime;              // 쿨타임
    public float magnet;                // 자석

    public float luck;                  // 행운(미정)
    public float expMultiplier;         // 경험치 배율
    public float goldMultiplier;        // 골드 배율(미정)

    // 레벨업 당 올라가는 능력치 -> 지울수도
    public StatsIncreasePerLevel statsIncreasePerLevel;

    [Serializable]
    public class StatsIncreasePerLevel
    {
        public float hp;
        public float hpRecovery;
        public float armor;
        public float attack;
    }
}