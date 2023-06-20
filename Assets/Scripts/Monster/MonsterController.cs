using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    private float moveSpeed = 1f;            // ���� �̵��ӵ�
    
    private Rigidbody2D rb;
    private Rigidbody2D target;

    private Collider2D col;
    private SpriteRenderer render;
    private Animator anim;

    private float hp = 10f;
    private float maxHp = 10f;
    private bool isAlive;
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
        rb.AddForce(dirVec.normalized * 5f, ForceMode2D.Impulse);   // �÷��̾��� �ݴ� �������� �˹�

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
        else
            return;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
