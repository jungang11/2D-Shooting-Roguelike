using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] Fire[] firePrefabs;     // ÃÑ¾Ë

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
        for(int i =0;i<firePrefabs.Length;i++)
        {
            Fire fire = GameManager.Pool.Get(firePrefabs[i], transform.position, transform.rotation);
            fire.SetTarget(enemy);
            fire.SetDamage(1f);
        }
    }

    public MonsterController NearMonster()
    {
        float diff = 50f;

        for (int i = 0; i < monsterList.Count; i++)
        {
            float curDiff = Vector3.Distance(transform.position, monsterList[i].transform.position);

            if (curDiff < diff)
            {
                diff = curDiff;
                nearMonster = monsterList[i];
                return nearMonster;
            }
        }
        return null;
    }
}
