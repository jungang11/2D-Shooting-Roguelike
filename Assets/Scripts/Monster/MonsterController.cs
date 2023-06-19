using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;            // ���� �̵��ӵ�
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
        // ������ x�� ���� �÷��̾��� x�� ������ ���� ��� flipX �� true, �÷��̾� ������ ������ ��
        render.flipX = player.position.x > rb.position.x;
    }

    private void Chase()
    {
        // monster���� player�� ���� ������ ���ϰ� �÷��̾��� �������� ���������� �̵�
        Vector2 dirVec = player.position - rb.position;
        rb.MovePosition(rb.position + dirVec.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
