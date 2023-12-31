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
    private SpriteRenderer render;  // 캐릭터 flip 변경
    public MonsterScan scanner;     // 몬스터 스캔
    public Transform playerPos;     // 플레이어 위치

    public float moveSpeed;
    private Vector2 inputDir;       // InputSystem 입력받은 Vector2

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
        StartCoroutine(MoveRoutine());   // 지속적인 움직임
    }

    private void OnDisable()
    {
        StopCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            // transform.position 보다 Moveposition이 더 부드럽게 움직임(Rigidbody의 Interpolate 옵션 때문)
            // transform.position 으로 이동하는 경우 모든 Collider들이 Rigidbody의 위치를 재계산
            // inputDir을 normalized 하지 않을 경우 대각선 이동이 더 빠르며 이동속도가 비정상적
            GameManager.Data.playerPos = transform; // 플레이어의 위치

            rb.MovePosition(rb.position + playerData.movementSpeed * Time.fixedDeltaTime * inputDir.normalized);
            yield return null;
        }
    }

    private void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        // Animator Parameter 의 Speed 값 변경. magnitude : 순수한 크기
        anim.SetFloat("Speed", inputDir.magnitude);
        // 이동중일 때 입력 방향에 따라 render의 flipX 변경
        if (inputDir.x != 0)
        {
            render.flipX = (inputDir.x > 0);
        }
    }

    public void TakeHit(float damage)
    {
        // 방어력이 데미지보다 클 경우 hp는 0.01f만 감소
        if (damage < playerData.armor)
            HP -= 0.01f;
        // 아닐 경우 
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
