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
        texts["LevelText"].text = $"���� : {playerData.level}";
        texts["DamageText"].text = $"���ݷ� : {playerData.damage}";
        texts["SpeedText"].text = $"�̵��ӵ� : {GameManager.Data.currentPlayerData.movementSpeed}";

        texts["HpText"].text = $"ü�� : {GameManager.Data.currentPlayerData.hp}";
        texts["HpRecoveryText"].text = $"ü�� ȸ���� : {GameManager.Data.currentPlayerData.hpRecovery}";
        texts["ArmorText"].text = $"���� : {GameManager.Data.currentPlayerData.armor}";

        texts["CriticalRateText"].text = $"ũ��Ƽ�� Ȯ�� : {GameManager.Data.currentPlayerData.criticalRate}";
        texts["AreaText"].text = $"���� ���� : {GameManager.Data.currentPlayerData.area}";
        texts["ProjectileSpeedText"].text = $"���� �ӵ� : {GameManager.Data.currentPlayerData.projectileSpeed}";
        texts["DurationText"].text = $"���ӽð� : {GameManager.Data.currentPlayerData.duration}";
        texts["CoolTimeText"].text = $"��Ÿ�� : {GameManager.Data.currentPlayerData.coolTime}";

        texts["MagnetText"].text = $"�ڼ� : {GameManager.Data.currentPlayerData.magnet}";
        texts["LuckText"].text = $"��� : {GameManager.Data.currentPlayerData.luck}";
        texts["ExpMultiplierText"].text = $"����ġ ���� : {GameManager.Data.currentPlayerData.expMultiplier}";
        texts["GoldMultiplierText"].text = $"��� ���� : {GameManager.Data.currentPlayerData.goldMultiplier}";

        yield return null;
    }
}
