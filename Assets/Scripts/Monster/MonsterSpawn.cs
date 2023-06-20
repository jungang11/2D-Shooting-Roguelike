using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] float spawnDelay;  // ���� ���� ������
    [SerializeField] GameObject spawnPrefab;

    private BoxCollider2D area; // ���� ���� ����
    public List<GameObject> monsters = new List<GameObject>();  // ���� ����Ʈ

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
            // Vector3 ���� ���� ��ġ�� �޾ƿ�
            Vector3 spawnPos = GetRandomPosition();

            // ������ enemyPrefab�� ���� spawnPos�� ������ ����Ʈ�� �߰�. spawnDelay �ð��� ���� �� �ݺ�
            GameObject instance = GameManager.Pool.Get<GameObject>(spawnPrefab, spawnPos, Quaternion.identity);
            // monsters.Add(instance);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePoint = transform.position; // ������Ʈ ��ġ
        Vector2 size = area.size;   // Rigidbody2D �� ������

        //x, y�� ���� ��ǥ ���
        float posX = basePoint.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePoint.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}
