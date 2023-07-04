using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHolder : RangedWeapon
{
    public List<Bullet> bullets = new List<Bullet>();  // Bullet Pooling 리스트
    public Bullet bulletPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // poolSize만큼 리스트를 담은 후 스폰
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
                // 가까운 적이 없을경우 null 반환
                if (player.scanner.nearestEnemy != null)
                {
                    // 가장 가까운 적의 위치 구하기
                    targetPoint = player.scanner.nearestEnemy.position;
                    dirVec = (targetPoint - transform.position).normalized;

                    for (int i = 0; i < poolSize; i++)
                    {
                        if (bullets[i].gameObject.activeSelf == true) // 이미 setActive가 true 일 경우 넘어감
                            continue;

                        // 총알의 위치를 spawnPos로 설정 후 활성화 및 데이터 설정
                        Vector3 spawnPos = transform.position;
                        bullets[i].transform.position = spawnPos;
                        bullets[i].gameObject.SetActive(true);
                        bullets[i].GetComponent<Bullet>().Init(dirVec);

                        break;
                    }
                    // 총알 발사 딜레이
                    yield return new WaitForSeconds(GameManager.Data.bulletData.Items[0].cooldown);
                }
                yield return null;
            }
            yield return null;
        }
    }
}
