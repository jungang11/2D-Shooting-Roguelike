using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHolder : RangedWeapon
{
    public List<Bullet> bullets = new List<Bullet>();  // Bullet Pooling ����Ʈ
    public Bullet bulletPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // poolSize��ŭ ����Ʈ�� ���� �� ����
        for (int i = 0; i < poolSize; i++)
        {
            bullets.Add(GameManager.Pool.Get(bulletPrefab));
            bullets[i].name = "Bullet " + i;
            bullets[i].gameObject.SetActive(false);
            bullets[i].transform.SetParent(GameManager.Pool.poolRoot.transform);
        }

        StartCoroutine(BulletRoutine());
    }

    private IEnumerator BulletRoutine()
    {
        while (true)
        {
            if (GameManager.Data.bulletData.Items[0].currentLevel > 0)
            {
                // ����� ���� ������� null ��ȯ
                if (player.scanner.nearestEnemy != null)
                {
                    // ���� ����� ���� ��ġ ���ϱ�
                    targetPoint = player.scanner.nearestEnemy.position;
                    dirVec = (targetPoint - transform.position).normalized;

                    for (int i = 0; i < poolSize; i++)
                    {
                        if (bullets[i].gameObject.activeSelf == true) // �̹� setActive�� true �� ��� �Ѿ
                            continue;

                        // �Ѿ��� ��ġ�� spawnPos�� ���� �� Ȱ��ȭ �� ������ ����
                        Vector3 spawnPos = transform.position;
                        bullets[i].transform.position = spawnPos;
                        bullets[i].gameObject.SetActive(true);
                        bullets[i].GetComponent<Bullet>().Init(dirVec);

                        break;
                    }
                    // �Ѿ� �߻� ������
                    yield return new WaitForSeconds(GameManager.Data.bulletData.Items[0].cooldown);
                }
                yield return null;
            }
            yield return null;
        }
    }
}
