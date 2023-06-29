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
    public int defaultDamage;              // �⺻ ���ݷ�
    public int characterDamageMultiplier;  // �÷��̾� ���ݷ� ��� ������ ���
    public int damage;

    public int cooldown;            // ��Ÿ��
    public int duration;            // ���ӽð�
    public float interval;          // ���� �� ������

    public float amount;            // ����
    public float knockbackPower;    // �˹� �Ŀ�
    public int size;                // ũ��
    public float speed;             // �ӵ�
    public float pierce;            // ���� Ƚ��

    // UpdateStats�Լ��� �÷��̾� ���Ⱑ ������ �� ��
    // ��ũ���ͺ� ������Ʈ�� �����ϴ� ���� �ƴ� ���� �����ؿ��� ����.
    public void UpdateStats(WeaponStats weaponStats)
    {
        defaultDamage = weaponStats.defaultDamage;
        characterDamageMultiplier = weaponStats.characterDamageMultiplier;
        damage = weaponStats.damage;
        cooldown = weaponStats.cooldown;
        duration = weaponStats.duration;
        interval = weaponStats.interval;
        amount = weaponStats.amount;
        knockbackPower = weaponStats.knockbackPower;
        size = weaponStats.size;
        speed = weaponStats.speed;
        pierce = weaponStats.pierce;
    }
}
