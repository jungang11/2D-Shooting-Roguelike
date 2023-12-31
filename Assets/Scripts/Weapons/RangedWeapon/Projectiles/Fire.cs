using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private CapsuleCollider2D col;
    public ItemData fireData;
    public PlayerData playerData;
    public float damage;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider2D>();

        fireData = GameManager.Data.fireData;
        playerData = GameManager.Data.currentPlayerData;
    }

    public void Init()
    {
        StartCoroutine(FireRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        if (GameManager.Data.fireData.Items[0].currentLevel > 0)
        {
            yield return new WaitForSeconds(fireData.Items[0].duration * playerData.duration);
            gameObject.SetActive(false);

            yield return null;
        }
        yield return null;
    }
}
