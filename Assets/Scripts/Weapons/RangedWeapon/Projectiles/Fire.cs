using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private CapsuleCollider2D col;
    public float damage;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider2D>();
    }

    public void Init()
    {
        StartCoroutine(FireRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator FireRoutine()
    {
        yield return new WaitForSeconds(2f);

        GameManager.Resource.Destroy(gameObject);

        yield return null;
    }
}
