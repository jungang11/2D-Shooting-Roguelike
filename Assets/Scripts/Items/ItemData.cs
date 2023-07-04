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
        public string itemName;         // 아이템 이름
        public string itemDesc;         // 아이템 설명
        public Sprite itemImg;          // 아이템 이미지 스프라이트
        public ItemType itemType;       // 아이템 타입 ( 근접, 원거리, 패시브 , 힐)

        public float baseDamage;        // 기본 데미지
        public float[] damages;
        public int baseCount;           // 기본 Count (갯수)
        public int[] counts;

        public int currentLevel;        // 아이템 현재 레벨
        public int maxLevel;            // 아이템 최대 레벨

        public float damage;            // 공격력
        public float cooldown;          // 쿨타임
        public float duration;          // 공격 지속 시간 (발사체 유지 시간)
        public float interval;          // 공격 간격 (Stay시 너무 많은 공격 방지)

        public int count;               // 갯수
        public float size;              // 크기
        public float speed;             // 속도
        public float pierce;            // 관통 횟수
    }
}
