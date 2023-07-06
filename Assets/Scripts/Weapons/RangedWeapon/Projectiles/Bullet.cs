using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;

    private Rigidbody2D rb;
    public ItemData bulletData;
    public PlayerData playerData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletData = GameManager.Data.bulletData;
        playerData = GameManager.Data.currentPlayerData;
    }

    // 발사 목표 지점, 데미지, 스피드 설정
    public void Init(Vector3 dirVec)
    {
        StartCoroutine(BulletRoutine(dirVec));
    }

    IEnumerator BulletRoutine(Vector3 dirVec)
    {
        while (true)
        {
            // 날아가는 도중에 업그레이드 하면 그 상태에서도 데미지와 스피드가 반영되도록 함
            damage = bulletData.Items[0].damage * playerData.damage;
            speed = bulletData.Items[0].speed * playerData.projectileSpeed;

            transform.rotation = Quaternion.FromToRotation(Vector3.up, dirVec);
            rb.velocity = dirVec * speed;

            yield return new WaitForSeconds(playerData.duration * bulletData.Items[0].duration);
            gameObject.SetActive(false);
            yield return null;
        }
    }
}
