using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public PlayerController player;
    public Vector3 targetPoint;
    public Vector3 dirVec;

    protected override void Awake()
    {
        base.Awake();

        player = GetComponentInParent<PlayerController>();
    }

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            // ����� ���� ������� null ��ȯ
            if (player.scanner.nearestEnemy != null)
            {
                Fire();
                Electricity();
                Explosion();
                // �Ѿ� �߻� ������
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Fire()
    {
        // ���� ����� ���� ��ġ ���ϱ�
        targetPoint = player.scanner.nearestEnemy.position;
        dirVec = (targetPoint - transform.position).normalized;
        // �߻�ü ���� �� �ʱ�ȭ
        Bullet bullet = GameManager.Resource.Instantiate<Bullet>("Prefab/Weapon/Bullet", transform.position, transform.rotation);
        bullet.Init(dirVec);
    }

    private void Electricity()
    {
        // ���� ����� ���� ��ġ ���ϱ�
        targetPoint = player.scanner.nearestEnemy.position;
        dirVec = (targetPoint - transform.position).normalized;
        // �߻�ü ���� �� �ʱ�ȭ
        Electricity elec = GameManager.Resource.Instantiate<Electricity>("Prefab/Weapon/Electricity", transform.position, transform.rotation);
        elec.Init(dirVec);
    }

    private void Explosion()
    {
        Transform targetPoint = player.scanner.nearestEnemy;

        Explosion explosion = GameManager.Resource.Instantiate<Explosion>("Prefab/Weapon/Explosion", targetPoint.position, targetPoint.rotation);
        explosion.Init();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            GameManager.Resource.Destroy(gameObject);
        }
    }
}
