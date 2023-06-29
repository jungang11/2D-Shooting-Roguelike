using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public enum ItemType { CloseWeapon, RangedWeapon, Passive, Heal }

    [SerializeField] ItemInfo[] items;
    public ItemInfo[] Items { get { return items; } }

    [Serializable]
    public class ItemInfo
    {
        public int itemId;
        public string itemName;
        public string itemDesc;
        public Sprite itemImg;
        public ItemType itemType;

        public float baseDamage;
        public int baseCount;
        public float[] damages;
        public int[] counts;

        public int rarity;
        public int maxAmount;
        public bool isAttachedPlayer;
        public WeaponStats[] levelData;
    }
}

[Serializable]
public class WeaponStats
{
    public int damage;

    public int cooldown;            // ��Ÿ��
    public float interval;          // ���� �� ������

    public float amount;            // ����
    public int size;                // ũ��
    public float speed;             // �ӵ�
    public float pierce;            // ���� Ƚ��

    // UpdateStats�Լ��� �÷��̾� ���Ⱑ ������ �� ��
    // ��ũ���ͺ� ������Ʈ�� �����ϴ� ���� �ƴ� ���� �����ؿ��� ����.
    public void UpdateStats(WeaponStats weaponStats)
    {
        damage = weaponStats.damage;
        cooldown = weaponStats.cooldown;
        interval = weaponStats.interval;
        amount = weaponStats.amount;
        size = weaponStats.size;
        speed = weaponStats.speed;
        pierce = weaponStats.pierce;
    }
}
