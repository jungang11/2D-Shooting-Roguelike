using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHolder : RangedWeapon
{
    public List<Explosion> explosions = new List<Explosion>();
    public Explosion explosionPrefab;

    public List<Fire> fires = new List<Fire>();
    public Fire firePrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // poolSize만큼 리스트를 담은 후 스폰
        for (int i = 0; i < poolSize; i++)
        {
            explosions.Add(GameManager.Pool.Get(explosionPrefab));
            explosions[i].name = "Explosion " + i;
            explosions[i].gameObject.SetActive(false);
            explosions[i].transform.SetParent(GameManager.Pool.poolRoot.transform);

            fires.Add(GameManager.Pool.Get(firePrefab));
            fires[i].name = "Fire " + i;
            fires[i].gameObject.SetActive(false);
            fires[i].transform.SetParent(GameManager.Pool.poolRoot.transform);
        }

        if (GameManager.Data.explosionData.Items[0].currentLevel > 0)
        {
            StartCoroutine(ExplosionRoutine());
        }
    }

    public void Init()
    {
        StartCoroutine(ExplosionRoutine());
    }

    private IEnumerator ExplosionRoutine()
    {
        while (true)
        {
            // 가까운 적이 없을경우 null 반환
            if (player.scanner.nearestEnemy != null)
            {
                Vector3 targetPoint = player.scanner.nearestEnemy.position;

                for (int i = 0; i < poolSize; i++)
                {
                    if (explosions[i].gameObject.activeSelf == true) // 이미 setActive가 true 일 경우 넘어감
                        continue;

                    explosions[i].transform.position = targetPoint;
                    explosions[i].gameObject.SetActive(true);
                    explosions[i].GetComponent<Explosion>().Init();

                    yield return new WaitForSeconds(playerData.duration * GameManager.Data.explosionData.Items[0].duration);

                    fires[i].transform.position = targetPoint;
                    fires[i].gameObject.SetActive(true);
                    fires[i].GetComponent<Fire>().Init();

                    break;
                }
                // 폭발 딜레이
                yield return new WaitForSeconds(GameManager.Data.explosionData.Items[0].cooldown);
            }
            yield return null;
        }
    }
}
