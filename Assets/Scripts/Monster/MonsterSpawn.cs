using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] float spawnDelay;  // 몬스터 생성 딜레이
    [SerializeField] GameObject spawnPrefab;

    private BoxCollider2D area; // 몬스터 생성 범위
    public List<GameObject> monsters = new List<GameObject>();  // 몬스터 리스트

    private void Awake()
    {
        area = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
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
            // Vector3 값인 랜덤 위치를 받아옴
            Vector3 spawnPos = GetRandomPosition();

            // 설정된 enemyPrefab을 랜덤 spawnPos에 생성후 리스트에 추가. spawnDelay 시간이 지난 후 반복
            GameObject instance = GameManager.Pool.Get<GameObject>(spawnPrefab, spawnPos, Quaternion.identity);
            // monsters.Add(instance);
            yield return new WaitForSeconds(spawnDelay);
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
