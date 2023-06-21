using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData data;
    public int level = 1;
    public Weapon weapon;
    public Image image;
    public TMP_Text levelText;

    private void Awake()
    {
        // [0]은 자기 자신
        image = GetComponentsInChildren<Image>()[1];
        image.sprite = data.Items[0].itemImg;

        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        levelText = texts[0];
    }

    public void LevelUpText()
    {
        levelText.text = ($"Lv {level++}");
    }

    public void OnClick()
    {
        switch (data.Items[0].itemType)
        {
            case ItemData.ItemType.CloseWeapon:

                break;
            case ItemData.ItemType.RangedWeapon:

                break;
            case ItemData.ItemType.Passive:

                break;
            case ItemData.ItemType.Heal:

                break;
        }
        level++;

        if(level == data.Items[0].damages.Length)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
