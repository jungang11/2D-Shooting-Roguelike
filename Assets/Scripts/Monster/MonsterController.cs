using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    public HitDamage hitDamage;

    private float moveSpeed = 1f;            // ���� �̵��ӵ�
    
    private Rigidbody2D rb;
    private Rigidbody2D target;

    private Collider2D col;
    private SpriteRenderer render;
    private Animator anim;

    private float hp;
    private float maxHp = 10f;
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
    }

    public void Init()
    {
        isAlive = true;
        hp = maxHp;
    }

    private void FixedUpdate()
    {
        // ���� ���°� Alive�� �ƴϰų� / TakeHit �ִϸ��̼��� �������� �� return
        if (!isAlive || anim.GetCurrentAnimatorStateInfo(0).IsName("TakeHit"))
            return;

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


    IEnumerator TakeHitRoutine()
    {
        Vector3 dirVec = transform.position - target.transform.position;    // �÷��̾� ������ �ݴ� ����
        rb.AddForce(dirVec.normalized * 4f, ForceMode2D.Force);   // �÷��̾��� �ݴ� �������� �˹�

        yield return null;
    }

    public void TakeHit(float damage)
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
            StartCoroutine(TakeHitRoutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeHit(collision.GetComponent<Bullet>().damage);
            GameManager.Resource.Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Electricity"))
        {
            TakeHit(collision.GetComponent<Electricity>().damage);
            GameManager.Resource.Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Explosion"))
        {
            TakeHit(collision.GetComponent<Explosion>().damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            TakeHit(collision.GetComponent<Fire>().damage);
        }
        if (collision.gameObject.CompareTag("CloseWeapon"))
        {
            TakeHit(collision.GetComponent<CloseWeapon>().damage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target.GetComponent<PlayerController>().TakeHit(0.2f);
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
