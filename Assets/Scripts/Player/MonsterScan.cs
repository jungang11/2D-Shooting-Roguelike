using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScan : MonoBehaviour
{
    public LayerMask enemyMask;     // 몬스터 레이어 마스크
    public float range;             // 몬스터 감지 범위
    public RaycastHit2D[] enemies;  // 레이캐스트가 닿은 몬스터들 
    public Transform nearestEnemy;  // 가장 가까운 enemy Transform

    void FixedUpdate()
    {
        enemies = Physics2D.CircleCastAll(transform.position, range, Vector2.zero, 0, enemyMask);
        nearestEnemy = GetNearest();
        range = GameManager.Data.currentPlayerData.area;
    }

    public Transform GetNearest()
    {
        Transform result;
        float diff = 100f;
        for (int i = 0; i < enemies.Length; i++)
        {
            float curDiff = Vector3.Distance(transform.position, enemies[i].transform.position);

            if (curDiff < diff)
            {
                diff = curDiff;
                result = enemies[i].transform;
                return result;
            }
        }
        return null;
    }
}
