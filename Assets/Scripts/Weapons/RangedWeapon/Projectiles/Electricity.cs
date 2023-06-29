using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public float damage;
    public float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 발사 목표 지점, 데미지, 스피드 설정
    public void Init(Vector3 dirVec)
    {
        StartCoroutine(ElecRoutine(dirVec));
    }

    IEnumerator ElecRoutine(Vector3 dirVec)
    {
        while (true)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.left, dirVec);
            rb.velocity = dirVec * speed;

            yield return new WaitForSeconds(2f);
            GameManager.Resource.Destroy(gameObject);

            yield return null;
        }
    }
}
