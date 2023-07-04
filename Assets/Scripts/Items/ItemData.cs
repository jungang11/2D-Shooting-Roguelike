using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public enum ItemType { NormalSword, Bullet, Electricity, Explosion, Fire,
                           Armor, MovementSpeed, Damage, Potion }

    [SerializeField] ItemInfo[] items;
    public ItemInfo[] Items { get { return items; } }

    [Serializable]
    public class ItemInfo
    {
        public int itemId;              // itemId
        public string itemName;         // ������ �̸�
        public string itemDesc;         // ������ ����
        public Sprite itemImg;          // ������ �̹��� ��������Ʈ
        public ItemType itemType;       // ������ Ÿ�� ( ����, ���Ÿ�, �нú� , ��)

        public float baseDamage;        // �⺻ ������
        public float[] damages;
        public int baseCount;           // �⺻ Count (����)
        public int[] counts;

        public int currentLevel;        // ������ ���� ����
        public int maxLevel;            // ������ �ִ� ����

        public float damage;            // ���ݷ�
        public float cooldown;          // ��Ÿ��
        public float duration;          // ���� ���� �ð� (�߻�ü ���� �ð�)
        public float interval;          // ���� ���� (Stay�� �ʹ� ���� ���� ����)

        public int count;               // ����
        public float size;              // ũ��
        public float speed;             // �ӵ�
        public float pierce;            // ���� Ƚ��
    }
}
