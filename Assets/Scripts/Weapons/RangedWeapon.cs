using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] Transform firePoint;       // �Ѿ� �߻� ��ġ
    [SerializeField] Fire firePrefab;     // �Ѿ�

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
                yield return new WaitForSeconds(0.2f);  // �Ѿ� �߻� ������
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Fire(MonsterController enemy)
    {
        // ���ҽ��Ŵ����� �̿��� Resource�� Fire �������� ������ ���
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
                // ���Ⱑ �� ó�� �����ϴ� ������ ��ġ�� �ٶ󺸰� ��
                Vector3 dir = (monsterList[0].transform.position - transform.position);
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            yield return null;
        }
    }
}
