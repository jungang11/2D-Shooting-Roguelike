using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float moveSpeed = 1f;            // 몬스터 이동속도
    
    private Rigidbody2D rb;
    private Rigidbody2D target;
    private SpriteRenderer render;

    private float hp = 1f;
    private bool isAlive = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Chase();
    }

    private void LateUpdate()
    {
        // 몬스터의 x축 값이 플레이어의 x축 값보다 작을 경우 flipX 가 true, 플레이어 방향을 보도록 함
        render.flipX = target.position.x > rb.position.x;
    }

    private void Chase()
    {
        // monster에서 player로 가는 방향을 구하고 플레이어의 방향으로 지속적으로 이동
        Vector2 dirVec = target.position - rb.position;
        rb.MovePosition(rb.position + dirVec.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeHit(float damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CloseWeapon"))
        {
            TakeHit(collision.GetComponent<Spear>().damage);
        }
        else if (collision.CompareTag("Fire"))
        {
            TakeHit(collision.GetComponent<Fire>().FireDamage);
        }
        else
            return;
    }

    public void Die()
    {
        isAlive = false;
        gameObject.SetActive(false);
    }
}
