using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    private float moveSpeed = 1f;            // 몬스터 이동속도
    
    private Rigidbody2D rb;
    private Rigidbody2D target;

    private Collider2D col;
    private SpriteRenderer render;
    private Animator anim;

    private float hp = 10f;
    private float maxHp = 10f;
    private bool isAlive = true;
    public bool IsAlive { get { return isAlive; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 현재 상태가 Alive가 아니거나 / TakeHit 애니메이션이 진행중일 때 return
        if (!isAlive || anim.GetCurrentAnimatorStateInfo(0).IsName("TakeHit"))
            return;

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

    IEnumerator TakeHitRoutine()
    {
        Vector3 dirVec = transform.position - target.transform.position;    // 플레이어 기준의 반대 방향
        rb.AddForce(dirVec.normalized * 4f, ForceMode2D.Force);   // 플레이어의 반대 방향으로 넉백

        yield return null;
    }

    public void TakeHit(float damage)
    {
        anim.SetTrigger("TakeHit");

        hp -= damage;
        if (hp < 0)
        {
            isAlive = false;
            col.enabled = false;
            rb.simulated = false;
            render.sortingOrder = -2;
            Die();
            GameManager.Data.kill++;
            GameManager.Data.GetExp();
        }
        else
        {
            StartCoroutine(TakeHitRoutine());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("CloseWeapon"))
        {
            TakeHit(collision.GetComponent<CloseWeapon>().damage);
        }
        else if (collision.CompareTag("Fire"))
        {
            TakeHit(collision.GetComponent<Fire>().FireDamage);
        }
        else if (collision.CompareTag("Player"))
        {
            player.TakeHit(1f);
        }
        else if (!isAlive)
            return;
        else
            return;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
