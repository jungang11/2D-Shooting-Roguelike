using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float damage;
    public float speed;

    private Rigidbody2D rb;
    private Vector3 dirVec;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 발사 목표 지점, 데미지, 스피드 설정
    public void Init(Vector3 targetPoint)
    {
        StartCoroutine(FireRoutine(targetPoint));
    }

    IEnumerator FireRoutine(Vector3 targetPoint)
    {
        while (true)
        {
            dirVec = targetPoint - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, dirVec.normalized);
            rb.velocity = dirVec.normalized * speed;

            if (targetPoint == null)
            {
                rb.velocity = transform.forward * speed;
                GameManager.Resource.Destroy(gameObject, 1f);
            }

            yield return null;
        }
    }
}
