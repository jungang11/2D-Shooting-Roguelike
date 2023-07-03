using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloseWeapon : Weapon
{
    public float damage;                        // 데미지
    public int count;                           // 배치 무기 갯수
    public float speed;                         // 속도
    public CloseWeapon closeWeaponPrefab;       // 배치될 프리팹
    public ItemData swordData;

    protected override void Awake()
    {
        base.Awake();

        swordData = GameManager.Data.swordData;
    }

    private IEnumerator RotateRoutine()
    {
        while (true)
        {
            damage = swordData.Items[0].damage * GameManager.Data.currentPlayerData.damage;
            speed = swordData.Items[0].speed;

            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            yield return null;
        }
    }

private void Start()
    {
        Place();
        StartCoroutine(RotateRoutine());
    }

    /*private void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);

        damage = swordData.Items[0].damage * GameManager.Data.currentPlayerData.damage;
        speed = swordData.Items[0].speed;
    }*/

    // 캐릭터 주위 무기 배치
    public void Place()
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
