using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] Transform firePoint;   // �Ѿ� �߻� ��ġ

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
                Attack(monsterList[0]);
                Debug.Log("Attack");
                yield return new WaitForSeconds(0.2f);  // �Ѿ� �߻� ������
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Attack(MonsterController enemy)
    {
        // ���ҽ��Ŵ����� �̿��� Resource�� Fire �������� ������ ���
        Fire fire = GameManager.Resource.Instantiate<Fire>("Prefab/Fire", firePoint.position, firePoint.rotation);
        fire.SetTarget(enemy);
        fire.SetDamage(2f);
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
