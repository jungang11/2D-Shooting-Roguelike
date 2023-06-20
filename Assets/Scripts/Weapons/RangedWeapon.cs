using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] Transform firePoint;       // 총알 발사 위치
    [SerializeField] Fire firePrefab;     // 총알

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
        StartCoroutine(LookRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (monsterList.Count > 0)
            {
                Fire(monsterList[0]);
                yield return new WaitForSeconds(0.2f);  // 총알 발사 딜레이
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Fire(MonsterController enemy)
    {
        // 리소스매니저를 이용해 Resource의 Fire 프리팹을 가져와 사용
        Fire fire = GameManager.Pool.Get(firePrefab, firePoint.position, firePoint.rotation);
        fire.SetTarget(enemy);
        fire.SetDamage(1f);
    }

    IEnumerator LookRoutine()
    {
        while (true)
        {
            if (monsterList.Count > 0)
            {
                // 무기가 맨 처음 공격하는 몬스터의 위치를 바라보게 함
                Vector3 dir = (monsterList[0].transform.position - transform.position);
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            yield return null;
        }
    }
}
