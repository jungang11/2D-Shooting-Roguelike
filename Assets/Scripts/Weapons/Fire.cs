using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : RangedWeapon
{
    [SerializeField] float speed;   // 총알 발사 속도

    private MonsterController monster;
    private Rigidbody2D rb;
    private float damage;
    private Vector3 targetPoint;

    public float FireDamage { get { return damage; } }

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(MonsterController monster)
    {
        this.monster = monster;
        StartCoroutine(FireRoutine());
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            if (monster != null)
                targetPoint = monster.transform.position;

            // 타겟과 총알 사이 벡터를 구해 그 방향으로 회전 및 이동
            Vector2 dirVec = targetPoint - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, dirVec.normalized);
            rb.MovePosition(rb.position + dirVec.normalized * speed * Time.fixedDeltaTime);
            
            if (Vector2.Distance(targetPoint, transform.position) < 0.2f)
            {
                if (monster != null)
                    HitMonster(monster);

                GameManager.Pool.Release(gameObject);
                yield break;
            }

            yield return null;
        }
    }

    public void HitMonster(MonsterController monster)
    {
        monster.TakeHit(damage);
    }
}
