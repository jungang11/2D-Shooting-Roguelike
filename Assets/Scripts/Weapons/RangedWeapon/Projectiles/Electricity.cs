using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public float damage;
    public float speed;

    private Rigidbody2D rb;
    private ItemData electricityData;
    private PlayerData playerData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        electricityData = GameManager.Data.electricityData;
        playerData = GameManager.Data.currentPlayerData;
    }

    // �߻� ��ǥ ����, ������, ���ǵ� ����
    public void Init(Vector3 dirVec)
    {
        StartCoroutine(ElecRoutine(dirVec));
    }

    IEnumerator ElecRoutine(Vector3 dirVec)
    {
        while (true)
        {
            damage = electricityData.Items[0].damage * playerData.damage;
            speed = electricityData.Items[0].speed * playerData.projectileSpeed;

            // ���� ��������Ʈ ���� ���߱� ���� Vector3.left
            transform.rotation = Quaternion.FromToRotation(Vector3.left, dirVec);
            rb.velocity = dirVec * speed;

            yield return new WaitForSeconds(playerData.duration * electricityData.Items[0].duration);
            gameObject.SetActive(false);

            yield return null;
        }
    }
}
