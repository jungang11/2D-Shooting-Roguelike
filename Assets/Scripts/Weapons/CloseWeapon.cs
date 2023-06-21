using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloseWeapon : Weapon
{
    public float damage;                    // 데미지
    public int count;                       // 배치 무기 갯수
    public float speed;                     // 속도
    public CloseWeapon closeWeaponPrefab;   // 배치될 프리팹
    public Transform place;                 // 배치될 위치

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
        speed = 120f;
        Place();
    }

    // 캐릭터 주위 무기 배치
    public void Place()
    {
        for (int i = 0; i < count; i++)
        {
            place = GameManager.Pool.Get(closeWeaponPrefab).transform;
            place.SetParent(transform);

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            place.Rotate(rotVec);
            place.Translate(place.up * 2f, Space.World);
            place.GetComponent<Spear>().Setting(damage, -1);
        }
    }
}
