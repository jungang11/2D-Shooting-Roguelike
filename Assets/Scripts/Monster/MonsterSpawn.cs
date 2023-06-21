using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] float spawnDelay;          // ���� ���� ������
    [SerializeField] GameObject[] spawnPrefabs; // ���� ���� �����յ�

    private BoxCollider2D area;                                 // ���� ���� ����
    public List<GameObject> monsters = new List<GameObject>();  // ���� ����Ʈ
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
            // ���� ������
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0 ; i < poolSize; i++)
            {
                if (monsters[i].activeSelf == true) // �̹� setActive�� true �� ��� �Ѿ
                    continue;

                // Vector3 ���� ���� ��ġ�� �޾ƿ�
                Vector3 spawnPos = GetRandomPosition();

                // ������ ��ġ�� spawnPos�� ���� �� Ȱ��ȭ
                monsters[i].transform.position = spawnPos;
                monsters[i].SetActive(true);
                monsters[i].GetComponent<MonsterController>().Init();

                break;
            }
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
