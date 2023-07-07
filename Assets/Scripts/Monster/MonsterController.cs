using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    public HitDamage hitDamage;

    private float moveSpeed = 1f;            // ���� �̵��ӵ�
    
    private Rigidbody2D rb;
    private Transform target;
    private Collider2D col;
    private SpriteRenderer render;
    private Animator anim;

    public float hp;
    private float maxHp;
    private bool isAlive;
    public bool IsAlive { get { return isAlive; } }
    public bool isPrintDamage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Init();
        StartCoroutine(ChaseRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(ChaseRoutine());
    }

    public void Init()
    {
        isAlive = true;
        // ���� ���� �ð��� ����ؼ� ������ ü���� ����
        maxHp = 10f + GameManager.Data.gameTime;
    }

    private IEnumerator ChaseRoutine()
    {
        while (true)
        {
            target = GameManager.Data.playerPos;

            // ���� ���°� Alive�� �ƴϰų� / TakeHit �ִϸ��̼��� �������� �� return
            if (isAlive || !anim.GetCurrentAnimatorStateInfo(0).IsName("TakeHit"))
            {
                // ������ x�� ���� �÷��̾��� x�� ������ ���� ��� flipX �� true, �÷��̾� ������ ������ ��
                render.flipX = target.position.x > rb.position.x;

                // monster���� player�� ���� ������ ���ϰ� �÷��̾��� �������� ���������� �̵�
                Vector2 dirVec = (Vector2)target.position - rb.position;
                rb.MovePosition(rb.position + dirVec.normalized * moveSpeed * Time.fixedDeltaTime);
            }
            if(GameManager.Data.currentPlayerData.hp < 0)
            {
                gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    public void TakeHit(float damage, float interval)
    {
        anim.SetTrigger("TakeHit");

        if(GameManager.Data.isPrintDamage)
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
            Vector3 dirVec = transform.position - target.transform.position;    // �÷��̾� ������ �ݴ� ����
            rb.AddForce(dirVec.normalized * 3f, ForceMode2D.Force);   // �÷��̾��� �ݴ� �������� �˹�
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
