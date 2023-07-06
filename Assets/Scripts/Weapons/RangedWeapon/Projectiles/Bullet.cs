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

    // �߻� ��ǥ ����, ������, ���ǵ� ����
    public void Init(Vector3 dirVec)
    {
        StartCoroutine(BulletRoutine(dirVec));
    }

    IEnumerator BulletRoutine(Vector3 dirVec)
    {
        while (true)
        {
            // ���ư��� ���߿� ���׷��̵� �ϸ� �� ���¿����� �������� ���ǵ尡 �ݿ��ǵ��� ��
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
