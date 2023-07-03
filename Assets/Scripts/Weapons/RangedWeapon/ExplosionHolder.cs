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
        // Bullet�� ���� ������ 0(���Ⱑ ���� ����)�� �ƴ� ��� �Ѿ� �߻�
        if (GameManager.Data.explosionData.Items[0].currentLevel > 0)
        {
            StartCoroutine(ExplosionRoutine());
        }
    }

    private IEnumerator ExplosionRoutine()
    {
        while (true)
        {
            // ����� ���� ������� null ��ȯ
            if (player.scanner.nearestEnemy != null)
            {
                ExplosionInit();
                // �Ѿ� �߻� ������
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
