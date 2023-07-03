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
        texts["SpeedText"].text = $"�̵��ӵ� : {playerData.movementSpeed}";

        texts["HpText"].text = $"ü�� : {playerData.hp}";
        texts["HpRecoveryText"].text = $"ü�� ȸ���� : {playerData.hpRecovery}";
        texts["ArmorText"].text = $"���� : {playerData.armor}";

        texts["CriticalRateText"].text = $"ũ��Ƽ�� Ȯ�� : {playerData.criticalRate}";
        texts["AreaText"].text = $"���� ���� : {playerData.area}";
        texts["ProjectileSpeedText"].text = $"���� �ӵ� : {playerData.projectileSpeed}";
        texts["DurationText"].text = $"���ӽð� : {playerData.duration}";
        texts["CoolTimeText"].text = $"��Ÿ�� : {playerData.coolTime}";

        texts["MagnetText"].text = $"�ڼ� : {playerData.magnet}";
        texts["LuckText"].text = $"��� : {playerData.luck}";
        texts["ExpMultiplierText"].text = $"����ġ ���� : {playerData.expMultiplier}";
        texts["GoldMultiplierText"].text = $"��� ���� : {playerData.goldMultiplier}";

        yield return null;
    }
}
