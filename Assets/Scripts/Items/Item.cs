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
        // [0]�� �ڱ� �ڽ�
        image = GetComponentsInChildren<Image>()[1];
        image.sprite = data.Items[0].itemImg;

        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        levelText = texts[0];
    }

    public void ClickButton()
    {
        levelText.text = ($"Lv {level++}");
    }
}
