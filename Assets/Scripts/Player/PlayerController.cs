using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float hp;

    private Rigidbody2D rb;         // RigidBody2D
    private Animator anim;          // Animator
    private SpriteRenderer render;  // ĳ���� flip ����
    public MonsterScan scanner;     // ���� ��ĵ

    private Vector2 inputDir;       // InputSystem �Է¹��� Vector2

    public float HP { get { return hp; } private set { hp = value; OnChangedHP?.Invoke(hp); } }

    public UnityEvent<float> OnChangedHP;
    public UnityEvent OnDied;

    public float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        scanner = GetComponent<MonsterScan>();
    }

    private void FixedUpdate()
    {
        Move();   // �������� ������
    }

    private void Move()
    {
        // transform.position ���� Moveposition�� �� �ε巴�� ������(Rigidbody�� Interpolate �ɼ� ����)
        // transform.position ���� �̵��ϴ� ��� ��� Collider���� Rigidbody�� ��ġ�� ����
        // inputDir�� normalized ���� ���� ��� �밢�� �̵��� �� ������ �̵��ӵ��� ��������
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * inputDir.normalized);
    }

    private void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        // Animator Parameter �� Speed �� ����. magnitude : ������ ũ��
        anim.SetFloat("Speed", inputDir.magnitude);
        // �̵����� �� �Է� ���⿡ ���� render�� flipX ����
        if (inputDir.x != 0)
        {
            render.flipX = (inputDir.x > 0);
        }
    }

    public void TakeHit(float damage)
    {
        HP -= damage;

        if (hp <= 0)
        {
            OnDied?.Invoke();
            GameManager.Resource.Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }
}
