using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        StartCoroutine(StatusRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(StatusRoutine());
    }

    IEnumerator StatusRoutine()
    {
        texts["LevelText"].text = $"레벨 : {playerData.level}";
        texts["DamageText"].text = $"공격력 : {playerData.damage}";
        texts["SpeedText"].text = $"이동속도 : {GameManager.Data.currentPlayerData.movementSpeed}";

        texts["HpText"].text = $"체력 : {GameManager.Data.currentPlayerData.hp}";
        texts["HpRecoveryText"].text = $"체력 회복력 : {GameManager.Data.currentPlayerData.hpRecovery}";
        texts["ArmorText"].text = $"방어력 : {GameManager.Data.currentPlayerData.armor}";

        texts["CriticalRateText"].text = $"크리티컬 확률 : {GameManager.Data.currentPlayerData.criticalRate}";
        texts["AreaText"].text = $"공격 범위 : {GameManager.Data.currentPlayerData.area}";
        texts["ProjectileSpeedText"].text = $"공격 속도 : {GameManager.Data.currentPlayerData.projectileSpeed}";
        texts["DurationText"].text = $"지속시간 : {GameManager.Data.currentPlayerData.duration}";
        texts["CoolTimeText"].text = $"쿨타임 : {GameManager.Data.currentPlayerData.coolTime}";

        texts["MagnetText"].text = $"자석 : {GameManager.Data.currentPlayerData.magnet}";
        texts["LuckText"].text = $"행운 : {GameManager.Data.currentPlayerData.luck}";
        texts["ExpMultiplierText"].text = $"경험치 배율 : {GameManager.Data.currentPlayerData.expMultiplier}";
        texts["GoldMultiplierText"].text = $"골드 배율 : {GameManager.Data.currentPlayerData.goldMultiplier}";

        yield return null;
    }
}
