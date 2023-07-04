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
                textDesc.text = $"{data.Items[0].itemDesc}, 데미지 {data.Items[0].damages[level] * 10f}% 증가, 갯수 {data.Items[0].counts[level]}개 증가";
                break;
            case ItemData.ItemType.Bullet:
                textDesc.text = $"{data.Items[0].itemDesc}, 데미지 {data.Items[0].damages[level] * 10f}% 증가, 연사속도 {data.Items[0].counts[level] * 10f}% 증가";
                break;
            case ItemData.ItemType.Electricity:
                textDesc.text = $"{data.Items[0].itemDesc}, 데미지 {data.Items[0].damages[level] * 10f}% 증가, 연사속도 {data.Items[0].counts[level] * 10f}% 증가";
                break;
            case ItemData.ItemType.Explosion:
                textDesc.text = $"{data.Items[0].itemDesc}, 데미지 {data.Items[0].damages[level] * 10f}% 증가, 쿨타임 {data.Items[0].counts[level] * 10f}% 감소";
                break;
            case ItemData.ItemType.Fire:
                textDesc.text = $"{data.Items[0].itemDesc}, 데미지 {data.Items[0].damages[level] * 10f}% 증가, 지속시간 {data.Items[0].counts[level]}초 증가";
                break;
            case ItemData.ItemType.Armor:
                textDesc.text = $"방어력 {data.Items[0].damages[level] * 10f}% 증가";
                break;
            case ItemData.ItemType.MovementSpeed:
                textDesc.text = $"이동속도 {data.Items[0].damages[level] * 10f}% 증가";
                break;
            case ItemData.ItemType.Damage:
                textDesc.text = $"공격력 {data.Items[0].damages[level] * 10f}% 증가";
                break;
            case ItemData.ItemType.Potion:
                textDesc.text = $"체력 {data.Items[0].damages[level]} 회복";
                break;
            default:
                textDesc.text = $"{data.Items[0].itemDesc}";
                break;
        }

        yield return null;
    }
}
