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
        texts["SpeedText"].text = $"이동속도 : {playerData.movementSpeed}";

        texts["HpText"].text = $"체력 : {playerData.hp}";
        texts["HpRecoveryText"].text = $"체력 회복력 : {playerData.hpRecovery}";
        texts["ArmorText"].text = $"방어력 : {playerData.armor}";

        texts["CriticalRateText"].text = $"크리티컬 확률 : {playerData.criticalRate}";
        texts["AreaText"].text = $"공격 범위 : {playerData.area}";
        texts["ProjectileSpeedText"].text = $"공격 속도 : {playerData.projectileSpeed}";
        texts["DurationText"].text = $"지속시간 : {playerData.duration}";
        texts["CoolTimeText"].text = $"쿨타임 : {playerData.coolTime}";

        texts["MagnetText"].text = $"자석 : {playerData.magnet}";
        texts["LuckText"].text = $"행운 : {playerData.luck}";
        texts["ExpMultiplierText"].text = $"경험치 배율 : {playerData.expMultiplier}";
        texts["GoldMultiplierText"].text = $"골드 배율 : {playerData.goldMultiplier}";

        yield return null;
    }
}
