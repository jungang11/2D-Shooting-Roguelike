using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public PlayerStats stats;

    public PlayerStats GetLevelStats(int level)
    {
        var calculatedStats = stats with { };
        var levelAmount = level - 1;
        calculatedStats.hp += calculatedStats.statsIncreasePerLevel.hp * levelAmount;
        calculatedStats.hpRecovery += calculatedStats.statsIncreasePerLevel.hpRecovery * levelAmount;
        calculatedStats.armor += calculatedStats.statsIncreasePerLevel.armor * levelAmount;
        calculatedStats.attack += calculatedStats.statsIncreasePerLevel.attack * levelAmount;
        return calculatedStats;
    }

}
