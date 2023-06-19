using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float speed;   // 총알 발사 속도

    private MonsterController monster;
    private Rigidbody2D rb;
    private float damage;
    private Vector3 targetPoint;

    private void Awake()
    {
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

            // 총알의 위치가 타겟의 위치와 가까워질 경우 공격으로 판정
            if (Vector2.Distance(targetPoint, transform.position) < 0.2f)
            {
                if (monster != null)
                    Attack(monster);

                GameManager.Resource.Destroy(gameObject);
                yield break;
            }

            yield return null;
        }
    }

    public void Attack(MonsterController monster)
    {
        monster.TakeHit(damage);
    }
}
