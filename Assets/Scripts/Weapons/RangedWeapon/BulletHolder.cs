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
        // Bullet�� ���� ������ 0(���Ⱑ ���� ����)�� �ƴ� ��� �Ѿ� �߻�
        if (GameManager.Data.bulletData.Items[0].currentLevel > 0)
        {
            StartCoroutine(BulletRoutine());
        }
    }

    private IEnumerator BulletRoutine()
    {
        while (true)
        {
            // ����� ���� ������� null ��ȯ
            if (player.scanner.nearestEnemy != null)
            {
                BulletInit();
                // �Ѿ� �߻� ������
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
        // ���� ����� ���� ��ġ ���ϱ�
        targetPoint = player.scanner.nearestEnemy.position;
        dirVec = (targetPoint - transform.position).normalized;
        // �߻�ü ���� �� �ʱ�ȭ
        Bullet bullet = GameManager.Resource.Instantiate<Bullet>("Prefab/Weapon/Bullet", transform.position, transform.rotation);
        bullet.Init(dirVec);
    }
}
