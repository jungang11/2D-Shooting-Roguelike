using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityHolder : RangedWeapon
{
    public List<Electricity> electricities = new List<Electricity>();
    public Electricity electricityPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // poolSize만큼 리스트를 담은 후 스폰
        for (int i = 0; i < poolSize; i++)
        {
            electricities.Add(GameManager.Pool.Get(electricityPrefab));
            electricities[i].name = "Electricity " + i;
            electricities[i].gameObject.SetActive(false);
            electricities[i].transform.SetParent(GameManager.Pool.poolRoot.transform);
        }

        StartCoroutine(ElectricityRoutine());
    }

    private IEnumerator ElectricityRoutine()
    {
        while (true)
        {
            if (GameManager.Data.electricityData.Items[0].currentLevel > 0)
            {
                // 가까운 적이 없을경우 null 반환
                if (player.scanner.nearestEnemy != null)
                {
                    // 가장 가까운 적의 위치 구하기
                    targetPoint = player.scanner.nearestEnemy.position;
                    dirVec = (targetPoint - transform.position).normalized;

                    for (int i = 0; i < poolSize; i++)
                    {
                        if (electricities[i].gameObject.activeSelf == true) // 이미 setActive가 true 일 경우 넘어감
                            continue;

                        Vector3 spawnPos = transform.position;
                        electricities[i].transform.position = spawnPos;
                        electricities[i].gameObject.SetActive(true);
                        electricities[i].GetComponent<Electricity>().Init(dirVec);

                        break;
                    }
                    // 총알 발사 딜레이
                    yield return new WaitForSeconds(GameManager.Data.electricityData.Items[0].cooldown);
                }
                yield return null;
            }
            yield return null;
        }
    }
}
