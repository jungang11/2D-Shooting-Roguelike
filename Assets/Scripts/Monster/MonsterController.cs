using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    public HitDamage hitDamage;

    private float moveSpeed = 1f;            // 몬스터 이동속도
    
    private Rigidbody2D rb;
    private Rigidbody2D target;
    private Collider2D col;
    private SpriteRenderer render;
    private Animator anim;

    public float hp;
    private float maxHp = 20f;
    private bool isAlive;
    public bool IsAlive { get { return isAlive; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Init();
        StartCoroutine(ChaseRoutine());
    }

    public void Init()
    {
        isAlive = true;
        hp = maxHp;
    }

    private IEnumerator ChaseRoutine()
    {
        while (true)
        {
            // 현재 상태가 Alive가 아니거나 / TakeHit 애니메이션이 진행중일 때 return
            if (isAlive || !anim.GetCurrentAnimatorStateInfo(0).IsName("TakeHit"))
            {
                // 몬스터의 x축 값이 플레이어의 x축 값보다 작을 경우 flipX 가 true, 플레이어 방향을 보도록 함
                render.flipX = target.position.x > rb.position.x;

                // monster에서 player로 가는 방향을 구하고 플레이어의 방향으로 지속적으로 이동
                Vector2 dirVec = target.position - rb.position;
                rb.MovePosition(rb.position + dirVec.normalized * moveSpeed * Time.fixedDeltaTime);
            }
            yield return null;
        }
    }

    public void TakeHit(float damage, float interval)
    {
        anim.SetTrigger("TakeHit");
        hitDamage.PrintDamage(damage);

        hp -= damage;
        if (hp < 0)
        {
            Die();
            GameManager.Data.currentPlayerData.kill++;
            GameManager.Data.GetExp();
        }
        else
        {
            Vector3 dirVec = transform.position - target.transform.position;    // 플레이어 기준의 반대 방향
            rb.AddForce(dirVec.normalized * 3f, ForceMode2D.Force);   // 플레이어의 반대 방향으로 넉백
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeHit(GameManager.Data.bulletData.Items[0].damage, 
                GameManager.Data.bulletData.Items[0].interval);
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Electricity"))
        {
            TakeHit(GameManager.Data.electricityData.Items[0].damage, 
                GameManager.Data.electricityData.Items[0].interval);
        }
        if (collision.CompareTag("Explosion"))
        {
            TakeHit(GameManager.Data.explosionData.Items[0].damage
                , GameManager.Data.explosionData.Items[0].interval);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            TakeHit(GameManager.Data.fireData.Items[0].damage,
                GameManager.Data.fireData.Items[0].interval);
        }
        if (collision.gameObject.CompareTag("CloseWeapon"))
        {
            TakeHit(GameManager.Data.swordData.Items[0].damage,
                GameManager.Data.swordData.Items[0].interval);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target.GetComponent<PlayerController>().TakeHit(1.2f);
        }
        else
            return;
    }

    public void Die()
    {
        anim.SetTrigger("Die");
        isAlive = false;
        gameObject.SetActive(false);
    }
}
