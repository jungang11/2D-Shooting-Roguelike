using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float moveSpeed = 1f;            // ���� �̵��ӵ�
    
    private Rigidbody2D rb;
    private Rigidbody2D target;

    private SpriteRenderer render;
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
        // ������ x�� ���� �÷��̾��� x�� ������ ���� ��� flipX �� true, �÷��̾� ������ ������ ��
        render.flipX = target.position.x > rb.position.x;
    }

    private void Chase()
    {
        // monster���� player�� ���� ������ ���ϰ� �÷��̾��� �������� ���������� �̵�
        Vector2 dirVec = target.position - rb.position;
        rb.MovePosition(rb.position + dirVec.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
