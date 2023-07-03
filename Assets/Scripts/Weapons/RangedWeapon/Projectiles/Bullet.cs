using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;

    private Rigidbody2D rb;
    private ItemData bulletData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletData = GameManager.Data.bulletData;
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
            damage = bulletData.Items[0].damage;
            speed = bulletData.Items[0].speed;

            transform.rotation = Quaternion.FromToRotation(Vector3.up, dirVec);
            rb.velocity = dirVec * speed;

            yield return new WaitForSeconds(2f);
            GameManager.Resource.Destroy(gameObject);

            yield return null;
        }
    }
}
