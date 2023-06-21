using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] Fire firePrefab;     // ÃÑ¾Ë
    private MonsterController nearMonster;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (monsterList.Count > 0)
            {
                Fire(NearMonster());
                yield return new WaitForSeconds(0.2f);  // ÃÑ¾Ë ¹ß»ç µô·¹ÀÌ
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Fire(MonsterController enemy)
    {
        Fire fire = GameManager.Pool.Get(firePrefab, transform.position, transform.rotation);
        fire.SetTarget(enemy);
        fire.SetDamage(1f);
    }

    public MonsterController NearMonster()
    {
        float diff = 50f;

        foreach (MonsterController monster in monsterList)
        {
            float curDiff = Vector3.Distance(transform.position, monster.transform.position);

            if (curDiff < diff)
            {
                diff = curDiff;
                nearMonster = monster;
                return nearMonster;
            }
        }
        return null;
    }
}
