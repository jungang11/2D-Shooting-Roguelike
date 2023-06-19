using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed; // �÷��̾� �̵��ӵ�

    private Rigidbody2D rb;         // RigidBody2D
    private Animator anim;          // Animator

    private Vector2 inputDir;       // InputSystem �Է¹��� Vector2

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
    }
}