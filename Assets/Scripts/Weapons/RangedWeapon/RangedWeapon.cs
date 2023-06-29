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
            // 가까운 적이 없을경우 null 반환
            if (player.scanner.nearestEnemy != null)
            {
                Fire();
                Electricity();
                // 총알 발사 딜레이
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
        // 가장 가까운 적의 위치 구하기
        Vector3 targetPoint = player.scanner.nearestEnemy.position;
        Vector3 dirVec = (targetPoint - transform.position).normalized;

        // 발사체 생성 및 초기화
        Fire fire = GameManager.Resource.Instantiate<Fire>("Prefab/Weapon/Fire", transform.position, transform.rotation);
        fire.Init(dirVec);
    }

    private void Electricity()
    {
        // 가장 가까운 적의 위치 구하기
        Vector3 targetPoint = player.scanner.nearestEnemy.position;
        Vector3 dirVec = (targetPoint - transform.position).normalized;

        // 발사체 생성 및 초기화
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
