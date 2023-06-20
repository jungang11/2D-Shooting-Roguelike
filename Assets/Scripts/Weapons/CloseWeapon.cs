using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloseWeapon : Weapon
{
    public float damage;
    public int count;
    public float speed;
    public Spear spearPrefab;
    public Transform place;

    // public float Damage { get { return damage; } }

    protected override void Awake()
    {
        base.Awake();
    }
     
    private void Start()
    {
        SetSpear();
    }

    private void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }

    public void SetSpear()
    {
        speed = 100f;
        Place();
    }

    // 캐릭터 주위 무기 배치
    public void Place()
    {
        for (int i = 0; i < count; i++)
        {
            place = GameManager.Pool.Get(spearPrefab).transform;
            place.SetParent(transform);

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            place.Rotate(rotVec);
            place.Translate(place.up * 1.5f, Space.World);
            place.GetComponent<Spear>().Setting(damage, -1);
        }
    }
}
