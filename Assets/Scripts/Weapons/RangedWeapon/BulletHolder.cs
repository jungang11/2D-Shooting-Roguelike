using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHolder : RangedWeapon
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // Bullet의 현재 레벨이 0(무기가 없는 상태)가 아닐 경우 총알 발사
        if (GameManager.Data.bulletData.Items[0].currentLevel > 0)
        {
            StartCoroutine(BulletRoutine());
        }
    }

    private IEnumerator BulletRoutine()
    {
        while (true)
        {
            // 가까운 적이 없을경우 null 반환
            if (player.scanner.nearestEnemy != null)
            {
                BulletInit();
                // 총알 발사 딜레이
                yield return new WaitForSeconds(GameManager.Data.bulletData.Items[0].cooldown);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void BulletInit()
    {
        // 가장 가까운 적의 위치 구하기
        targetPoint = player.scanner.nearestEnemy.position;
        dirVec = (targetPoint - transform.position).normalized;
        // 발사체 생성 및 초기화
        Bullet bullet = GameManager.Resource.Instantiate<Bullet>("Prefab/Weapon/Bullet", transform.position, transform.rotation);
        bullet.Init(dirVec);
    }
}
