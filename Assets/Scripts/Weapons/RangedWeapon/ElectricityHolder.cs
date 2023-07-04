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
        // poolSize��ŭ ����Ʈ�� ���� �� ����
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
                // ����� ���� ������� null ��ȯ
                if (player.scanner.nearestEnemy != null)
                {
                    // ���� ����� ���� ��ġ ���ϱ�
                    targetPoint = player.scanner.nearestEnemy.position;
                    dirVec = (targetPoint - transform.position).normalized;

                    for (int i = 0; i < poolSize; i++)
                    {
                        if (electricities[i].gameObject.activeSelf == true) // �̹� setActive�� true �� ��� �Ѿ
                            continue;

                        Vector3 spawnPos = transform.position;
                        electricities[i].transform.position = spawnPos;
                        electricities[i].gameObject.SetActive(true);
                        electricities[i].GetComponent<Electricity>().Init(dirVec);

                        break;
                    }
                    // �Ѿ� �߻� ������
                    yield return new WaitForSeconds(GameManager.Data.electricityData.Items[0].cooldown);
                }
                yield return null;
            }
            yield return null;
        }
    }
}
