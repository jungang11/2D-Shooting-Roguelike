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

    public TMP_Text textLevel;
    public TMP_Text textName;
    public TMP_Text textDesc;

    private void Awake()
    {
        // [0]�� �ڱ� �ڽ�
        image = GetComponentsInChildren<Image>()[2];
        image.sprite = data.Items[0].itemImg;

        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.Items[0].itemName;
    }

    private void OnEnable()
    {
        textLevel.text = $"Lv. {level}";

        switch (data.Items[0].itemType)
        {
            case ItemData.ItemType.CloseWeapon:
                textDesc.text = $"{data.Items[0].itemDesc}, ������ {data.Items[0].damages[level] * 10f}% ����, ���� {data.Items[0].counts[level]} ����";
                break;
            case ItemData.ItemType.RangedWeapon:
                textDesc.text = $"{data.Items[0].itemDesc}, ������ {data.Items[0].damages[level] * 10f}% ����";
                break;
            default:
                textDesc.text = $"{data.Items[0].itemDesc}";
                break;
        }
    }

    public void OnClick()
    {
        switch (data.Items[0].itemType)
        {
            case ItemData.ItemType.CloseWeapon:
                data.Items[0].baseCount++;
                break;
            case ItemData.ItemType.RangedWeapon:
                if(level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    newWeapon.AddComponent<RangedWeapon>();
                }
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
