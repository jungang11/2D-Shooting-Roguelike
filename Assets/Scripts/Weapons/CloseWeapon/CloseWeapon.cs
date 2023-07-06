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
        StartCoroutine(SwordRoutine());
    }

    private IEnumerator SwordRoutine()
    {
        while (true)
        {
            damage = swordData.Items[0].damage * GameManager.Data.currentPlayerData.damage;
            speed = swordData.Items[0].speed * GameManager.Data.currentPlayerData.coolTime;
            count = swordData.Items[0].count;

            transform.Rotate(Vector3.back * speed * Time.deltaTime);

            if (GameManager.Data.swordData.Items[0].currentLevel > 0)
            {
                // Sword
                for (int i = 0; i < count; i++)
                {
                    if (closeWeapons[i].gameObject.activeSelf == true) // �̹� setActive�� true �� ��� �Ѿ
                        continue;

                    closeWeapons[i].gameObject.SetActive(true);
                    closeWeapons[i].GetComponent<NormalSword>().Setting(damage, -1);

                    Vector3 rotVec = Vector3.forward * 360 * i / count;
                    closeWeapons[i].transform.Rotate(rotVec);
                    closeWeapons[i].transform.Translate(closeWeapons[i].transform.up * 3f, Space.World);
                }
                yield return null;
            }
            yield return null;
        }
    }
}
