using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage;
    public int poolSize;

    private ItemData explosionData;
    private PlayerData playerData;

    private void Awake()
    {
        explosionData = GameManager.Data.explosionData;
        playerData = GameManager.Data.currentPlayerData;
    }

    public void Init()
    {
        StartCoroutine(ExplosionRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(ExplosionRoutine());
    }

    public IEnumerator ExplosionRoutine()
    {
        damage = explosionData.Items[0].damage;

        yield return new WaitForSeconds(playerData.duration * explosionData.Items[0].duration);
        gameObject.SetActive(false);

        yield return null;
    }
}
