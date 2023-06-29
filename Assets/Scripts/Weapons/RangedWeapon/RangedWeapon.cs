using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public PlayerController player;

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
                // �Ѿ� �߻� ������
                yield return new WaitForSeconds(0.2f);
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
        Vector3 targetPoint = player.scanner.nearestEnemy.position;
        Vector3 dirVec = (targetPoint - transform.position).normalized;

        // �߻�ü ���� �� �ʱ�ȭ
        Fire fire = GameManager.Resource.Instantiate<Fire>("Prefab/Weapon/Fire", transform.position, transform.rotation);
        fire.Init(dirVec);
    }

    private void Electricity()
    {
        // ���� ����� ���� ��ġ ���ϱ�
        Vector3 targetPoint = player.scanner.nearestEnemy.position;
        Vector3 dirVec = (targetPoint - transform.position).normalized;

        // �߻�ü ���� �� �ʱ�ȭ
        Electricity elec = GameManager.Resource.Instantiate<Electricity>("Prefab/Weapon/Electricity", transform.position, transform.rotation);
        elec.Init(dirVec);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            GameManager.Resource.Destroy(gameObject);
        }
    }
}
