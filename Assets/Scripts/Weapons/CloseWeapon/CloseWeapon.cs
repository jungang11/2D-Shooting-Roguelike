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
    public ItemData swordData;

    protected override void Awake()
    {
        base.Awake();

        swordData = GameManager.Data.swordData;
    }

    private void Start()
    {
        SetSpear();
        StartCoroutine(RotateRoutine());
    }

    public void SetSpear()
    {
        speed = 200f;
        PlaceSword(swordData.Items[0].baseCount);
    }

    private IEnumerator RotateRoutine()
    {
        while (true)
        {
            damage = swordData.Items[0].damages[swordData.Items[0].currentLevel] 
                                            * GameManager.Data.currentPlayerData.damage;

            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            yield return null;
        }
    }

    // ĳ���� ���� ���� ��ġ
    public void PlaceSword(int count)
    {
        // Sword
        for (int i = 0; i < count; i++)
        {
            CloseWeapon sword = GameManager.Pool.Get<CloseWeapon>(closeWeaponPrefab);
            sword.transform.SetParent(transform);

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            sword.transform.Rotate(rotVec);
            sword.transform.Translate(sword.transform.up * 3f, Space.World);
            sword.transform.GetComponent<NormalSword>().Setting(damage, -1);
        }
    }
}
