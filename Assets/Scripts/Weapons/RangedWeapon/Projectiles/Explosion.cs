using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage;

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
        yield return new WaitForSeconds(0.2f);
        GameManager.Resource.Destroy(gameObject);
        Fire fire = GameManager.Resource.Instantiate<Fire>("Prefab/Weapon/Fire", transform.position, transform.rotation);
        fire.Init();

        yield return null;
    }
}
