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

        public GameObject weapon;
    }
}
