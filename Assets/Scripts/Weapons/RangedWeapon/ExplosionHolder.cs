using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHolder : RangedWeapon
{
    public List<Explosion> explosions = new List<Explosion>();
    public Explosion explosionPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        // poolSize��ŭ ����Ʈ�� ���� �� ����
        for (int i = 0; i < poolSize; i++)
        {
            explosions.Add(GameManager.Pool.Get(explosionPrefab));
            explosions[i].name = "Explosion " + i;
            explosions[i].gameObject.SetActive(false);
            explosions[i].transform.SetParent(GameManager.Pool.poolRoot.transform);
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
            // ����� ���� ������� null ��ȯ
            if (player.scanner.nearestEnemy != null)
            {
                Vector3 targetPoint = player.scanner.nearestEnemy.position;

                for (int i = 0; i < poolSize; i++)
                {
                    if (explosions[i].gameObject.activeSelf == true) // �̹� setActive�� true �� ��� �Ѿ
                        continue;

                    explosions[i].transform.position = targetPoint;
                    explosions[i].gameObject.SetActive(true);
                    explosions[i].GetComponent<Explosion>().Init();

                    break;
                }
                // ���� ������
                yield return new WaitForSeconds(GameManager.Data.explosionData.Items[0].cooldown);
            }
            yield return null;
        }
    }
}
