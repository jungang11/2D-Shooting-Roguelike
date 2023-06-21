using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] float spawnDelay;          // 몬스터 생성 딜레이
    [SerializeField] GameObject[] spawnPrefabs; // 스폰 몬스터 프리팹들

    private BoxCollider2D area;                                 // 몬스터 생성 범위
    public List<GameObject> monsters = new List<GameObject>();  // 몬스터 리스트
    private int poolSize = 10;

    private void Awake()
    {
        area = GetComponent<BoxCollider2D>();
    }

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
            // 스폰 딜레이
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0 ; i < poolSize; i++)
            {
                if (monsters[i].activeSelf == true) // 이미 setActive가 true 일 경우 넘어감
                    continue;

                // Vector3 값인 랜덤 위치를 받아옴
                Vector3 spawnPos = GetRandomPosition();

                // 몬스터의 위치를 spawnPos로 설정 후 활성화
                monsters[i].transform.position = spawnPos;
                monsters[i].SetActive(true);
                monsters[i].GetComponent<MonsterController>().Init();

                break;
            }
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePoint = transform.position; // 오브젝트 위치
        Vector2 size = area.size;   // Rigidbody2D 의 사이즈

        //x, y축 랜덤 좌표 얻기
        float posX = basePoint.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePoint.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}
