using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloseWeapon : Weapon
{
    public float damage;                        // ������
    public int count;                           // ��ġ ���� ����
    public float speed;                         // �ӵ�
    public CloseWeapon closeWeaponPrefab;       // ��ġ�� ������
    public Transform place;                     // ��ġ�� ��ġ
    private int index;

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
        speed = 200f;
        Place();
    }

    // ĳ���� ���� ���� ��ġ
    public void Place()
    {
        for (int i = 0; i < count; i++)
        {
            place = GameManager.Pool.Get(closeWeaponPrefab).transform;
            place.SetParent(transform);

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            place.Rotate(rotVec);
            place.Translate(place.up * 3f, Space.World);
            place.GetComponent<Spear>().Setting(damage, -1);
        }
    }
}
