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
    public Transform playerPos;     // �÷��̾� ��ġ

    public float moveSpeed;
    private Vector2 inputDir;       // InputSystem �Է¹��� Vector2

    public float HP { get { return hp; } private set { hp = value; OnChangedHP?.Invoke(hp); } }
    public UnityEvent<float> OnChangedHP;

    public PlayerData playerData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        scanner = GetComponent<MonsterScan>();
        playerData = GameManager.Data.currentPlayerData;
    }

    private void OnEnable()
    {
        StartCoroutine(MoveRoutine());   // �������� ������
    }

    private void OnDisable()
    {
        StopCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            // transform.position ���� Moveposition�� �� �ε巴�� ������(Rigidbody�� Interpolate �ɼ� ����)
            // transform.position ���� �̵��ϴ� ��� ��� Collider���� Rigidbody�� ��ġ�� ����
            // inputDir�� normalized ���� ���� ��� �밢�� �̵��� �� ������ �̵��ӵ��� ��������
            GameManager.Data.playerPos = transform; // �÷��̾��� ��ġ

            rb.MovePosition(rb.position + playerData.movementSpeed * Time.fixedDeltaTime * inputDir.normalized);
            yield return null;
        }
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
        // ������ ���������� Ŭ ��� hp�� 0.01f�� ����
        if (damage < playerData.armor)
            HP -= 0.01f;
        // �ƴ� ��� 
        else
            HP -= (damage - playerData.armor);

        if (hp <= 0)
            Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        GameManager.UI.ShowPopUpUI<PopUpUI>("Prefab/UI/DeadPopUpUI");
    }
}
