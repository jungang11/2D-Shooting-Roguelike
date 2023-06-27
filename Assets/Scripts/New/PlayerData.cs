using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public float hp;
    public float hpRecovery;
    public float armor;

    public float movementSpeed;

    public float attack;
    public float criticalRate;
    public float criticalMultiplier;

    public float area;
    public float projectileSpeed;
    public float duration;
    public float cooldown;
    public float magnet;

    public float luck;
    public float expMultiplier;
    public float goldMultiplier;

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
