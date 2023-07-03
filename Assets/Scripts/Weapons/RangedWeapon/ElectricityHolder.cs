using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityHolder : RangedWeapon
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // Bullet의 현재 레벨이 0(무기가 없는 상태)가 아닐 경우 총알 발사
        if (GameManager.Data.electricityData.Items[0].currentLevel > 0)
        {
            StartCoroutine(ElectricityRoutine());
        }
    }

    private IEnumerator ElectricityRoutine()
    {
        while (true)
        {
            // 가까운 적이 없을경우 null 반환
            if (player.scanner.nearestEnemy != null)
            {
                ElectricityInit();
                // 총알 발사 딜레이
                yield return new WaitForSeconds(GameManager.Data.electricityData.Items[0].cooldown);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void ElectricityInit()
    {
        // 가장 가까운 적의 위치 구하기
        targetPoint = player.scanner.nearestEnemy.position;
        dirVec = (targetPoint - transform.position).normalized;
        // 발사체 생성 및 초기화
        Electricity elec = GameManager.Resource.Instantiate<Electricity>("Prefab/Weapon/Electricity", transform.position, transform.rotation);
        elec.Init(dirVec);
    }
}
