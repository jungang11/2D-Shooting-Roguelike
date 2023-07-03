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
        // Bullet�� ���� ������ 0(���Ⱑ ���� ����)�� �ƴ� ��� �Ѿ� �߻�
        if (GameManager.Data.electricityData.Items[0].currentLevel > 0)
        {
            StartCoroutine(ElectricityRoutine());
        }
    }

    private IEnumerator ElectricityRoutine()
    {
        while (true)
        {
            // ����� ���� ������� null ��ȯ
            if (player.scanner.nearestEnemy != null)
            {
                ElectricityInit();
                // �Ѿ� �߻� ������
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
        // ���� ����� ���� ��ġ ���ϱ�
        targetPoint = player.scanner.nearestEnemy.position;
        dirVec = (targetPoint - transform.position).normalized;
        // �߻�ü ���� �� �ʱ�ȭ
        Electricity elec = GameManager.Resource.Instantiate<Electricity>("Prefab/Weapon/Electricity", transform.position, transform.rotation);
        elec.Init(dirVec);
    }
}
