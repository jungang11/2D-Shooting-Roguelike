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
    public List<CloseWeapon> closeWeapons = new List<CloseWeapon>();
    public ItemData swordData;

    protected override void Awake()
    {
        base.Awake();

        swordData = GameManager.Data.swordData;
    }

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            closeWeapons.Add(GameManager.Pool.Get(closeWeaponPrefab));
            closeWeapons[i].name = "CloseWeapon " + i;
            closeWeapons[i].gameObject.SetActive(false);
            closeWeapons[i].transform.SetParent(transform);
        }
        StartCoroutine(RotateRoutine());
    }

    private IEnumerator RotateRoutine()
    {
        while (true)
        {
            Vector3 rotVec = Vector3.forward * 360 / count;

            damage = swordData.Items[0].damage * GameManager.Data.currentPlayerData.damage;
            speed = swordData.Items[0].speed;
            count = swordData.Items[0].count;

            // Sword
            for (int i = 0; i < count; i++)
            {
                if (closeWeapons[i].gameObject.activeSelf == true) // 이미 setActive가 true 일 경우 넘어감
                    continue;

                closeWeapons[i].gameObject.SetActive(true);
                closeWeapons[i].GetComponent<NormalSword>().Setting(damage, -1);
                closeWeapons[i].transform.SetParent(transform);
                
                closeWeapons[i].transform.Rotate(rotVec);
                closeWeapons[i].transform.Translate(closeWeapons[i].transform.up * 3f, Space.World);
            }

            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            yield return null;
        }
    }
}
