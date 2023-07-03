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

    public List<Fire> fires = new List<Fire>();
    public Fire firePrefab;

    private void Awake()
    {
        explosionData = GameManager.Data.explosionData;
        playerData = GameManager.Data.currentPlayerData;
    }

    public void Init()
    {
        for (int i = 0; i < poolSize; i++)
        {
            fires.Add(GameManager.Pool.Get(firePrefab));
            fires[i].name = "Fire " + i;
            fires[i].gameObject.SetActive(false);
            fires[i].transform.SetParent(GameManager.Pool.poolRoot.transform);
        }
        
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

        for (int i = 0; i < poolSize; i++)
        {
            if (fires[i].gameObject.activeSelf == true) // 이미 setActive가 true 일 경우 넘어감
                continue;

            fires[i].transform.position = transform.position;
            fires[i].gameObject.SetActive(true);
            fires[i].GetComponent<Explosion>().Init();

            break;
        }

        yield return null;
    }
}
