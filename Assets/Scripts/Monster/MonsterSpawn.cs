using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] float spawnDelay;          // 몬스터 생성 딜레이
    [SerializeField] GameObject[] spawnPrefabs; // 스폰 몬스터 프리팹들
    [SerializeField] Transform[] spawnPoints;   // 스폰 위치들

    public List<GameObject> monsters = new List<GameObject>();  // 몬스터 리스트
    private int poolSize = 30;

    private void Start()
    {
        // poolSize만큼 리스트를 담은 후 스폰
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
            // 스폰 딜레이
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0 ; i < poolSize; i++)
            {
                if (monsters[i].activeSelf == true) // 이미 setActive가 true 일 경우 넘어감
                    continue;

                // Vector3 값인 위치를 받아옴
                Vector3 spawnPos = GetSpawnPos();

                // 몬스터의 위치를 spawnPos로 설정 후 활성화
                monsters[i].transform.position = spawnPos;
                monsters[i].SetActive(true);
                monsters[i].GetComponent<MonsterController>().Init();

                break;
            }
        }
    }

    // SpawnPoint 0~7 까지 중 랜덤으로 위치 받아옴
    private Vector2 GetSpawnPos()
    {
        return spawnPoints[(Random.Range(0, 8))].position;
    }
}
