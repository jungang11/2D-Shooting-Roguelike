using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] float spawnDelay;          // ���� ���� ������
    [SerializeField] GameObject[] spawnPrefabs; // ���� ���� �����յ�
    [SerializeField] Transform[] spawnPoints;

    public List<GameObject> monsters = new List<GameObject>();  // ���� ����Ʈ
    private int poolSize = 10;

    private void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            monsters.Add(GameManager.Pool.Get(spawnPrefabs[i]));
            monsters[i].name = "Enemy " + i;
            monsters[i].SetActive(false);
        }
        StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // ���� ������
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0 ; i < poolSize; i++)
            {
                if (monsters[i].activeSelf == true) // �̹� setActive�� true �� ��� �Ѿ
                    continue;

                // Vector3 ���� ��ġ�� �޾ƿ�
                Vector3 spawnPos = spawnPoints[i].position;

                // ������ ��ġ�� spawnPos�� ���� �� Ȱ��ȭ
                monsters[i].transform.position = spawnPos;
                monsters[i].SetActive(true);
                monsters[i].GetComponent<MonsterController>().Init();

                break;
            }
        }
    }
}
