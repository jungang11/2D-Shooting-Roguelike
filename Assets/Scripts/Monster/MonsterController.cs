using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;            // 몬스터 이동속도
    [SerializeField] private Rigidbody2D player;

    private Rigidbody2D rb;
    private SpriteRenderer render;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Chase();
    }

    private void LateUpdate()
    {
        // 몬스터의 x축 값이 플레이어의 x축 값보다 작을 경우 flipX 가 true, 플레이어 방향을 보도록 함
        render.flipX = player.position.x > rb.position.x;
    }

    private void Chase()
    {
        // monster에서 player로 가는 방향을 구하고 플레이어의 방향으로 지속적으로 이동
        Vector2 dirVec = player.position - rb.position;
        rb.MovePosition(rb.position + dirVec.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
