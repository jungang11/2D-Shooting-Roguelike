using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;

    public ItemData data;
    public int level = 1;
    public Weapon weapon;
    public Image image;
    public Image BackGroundImg;

    public TMP_Text textLevel;
    public TMP_Text textName;
    public TMP_Text textDesc;

    private void Awake()
    {
        BackGroundImg = GetComponentsInChildren<Image>()[1];

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
        StartCoroutine(ShowItemTextRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(ShowItemTextRoutine());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        BackGroundImg.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BackGroundImg.color = normal;
    }

    IEnumerator ShowItemTextRoutine()
    {
        textLevel.text = $"Lv. {level}";

        switch (data.Items[0].itemType)
        {
            case ItemData.ItemType.NormalSword:
                textDesc.text = $"{data.Items[0].itemDesc}, ������ {data.Items[0].damages[level] * 10f}% ����, ���� {data.Items[0].counts[level]}�� ����";
                break;
            case ItemData.ItemType.Bullet:
                textDesc.text = $"{data.Items[0].itemDesc}, ������ {data.Items[0].damages[level] * 10f}% ����, ����ӵ� {data.Items[0].counts[level] * 10f}% ����";
                break;
            case ItemData.ItemType.Electricity:
                textDesc.text = $"{data.Items[0].itemDesc}, ������ {data.Items[0].damages[level] * 10f}% ����, ����ӵ� {data.Items[0].counts[level] * 10f}% ����";
                break;
            case ItemData.ItemType.Explosion:
                textDesc.text = $"{data.Items[0].itemDesc}, ������ {data.Items[0].damages[level] * 10f}% ����, ��Ÿ�� {data.Items[0].counts[level] * 10f}% ����";
                break;
            case ItemData.ItemType.Fire:
                textDesc.text = $"{data.Items[0].itemDesc}, ������ {data.Items[0].damages[level] * 10f}% ����, ���ӽð� {data.Items[0].counts[level]}�� ����";
                break;
            case ItemData.ItemType.Armor:
                textDesc.text = $"���� {data.Items[0].damages[level] * 10f}% ����";
                break;
            case ItemData.ItemType.MovementSpeed:
                textDesc.text = $"�̵��ӵ� {data.Items[0].damages[level] * 10f}% ����";
                break;
            case ItemData.ItemType.Damage:
                textDesc.text = $"���ݷ� {data.Items[0].damages[level] * 10f}% ����";
                break;
            case ItemData.ItemType.Potion:
                textDesc.text = $"ü�� {data.Items[0].damages[level]} ȸ��";
                break;
            default:
                textDesc.text = $"{data.Items[0].itemDesc}";
                break;
        }

        yield return null;
    }
}
