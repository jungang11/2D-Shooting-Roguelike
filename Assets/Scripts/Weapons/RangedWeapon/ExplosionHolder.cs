using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHolder : RangedWeapon
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // Bullet의 현재 레벨이 0(무기가 없는 상태)가 아닐 경우 총알 발사
        if (GameManager.Data.explosionData.Items[0].currentLevel > 0)
        {
            StartCoroutine(ExplosionRoutine());
        }
    }

    private IEnumerator ExplosionRoutine()
    {
        while (true)
        {
            // 가까운 적이 없을경우 null 반환
            if (player.scanner.nearestEnemy != null)
            {
                ExplosionInit();
                // 총알 발사 딜레이
                yield return new WaitForSeconds(GameManager.Data.explosionData.Items[0].cooldown);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void ExplosionInit()
    {
        Transform targetPoint = player.scanner.nearestEnemy;

        Explosion explosion = GameManager.Resource.Instantiate<Explosion>("Prefab/Weapon/Explosion", targetPoint.position, targetPoint.rotation);
        explosion.Init();
    }
}
