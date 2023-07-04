using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class ItemsLevelUI : SceneUI
{
    [SerializeField] Color maxLevelColor;

    public ItemData data;
    public Image image;
    public Image backGroundImg;

    public TMP_Text textLevel;

    protected override void Awake()
    {
        base.Awake();

        backGroundImg = GetComponentsInChildren<Image>()[1];

        image = GetComponentsInChildren<Image>()[2];
        image.sprite = data.Items[0].itemImg;

        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        textLevel = texts[0];
    }

    private void OnEnable()
    {
        StartCoroutine(ShowLevelUIRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(ShowLevelUIRoutine());
    }

    IEnumerator ShowLevelUIRoutine()
    {
        while (true)
        {
            switch (data.Items[0].itemType)
            {
                case ItemData.ItemType.NormalSword:
                    textLevel.text = $"Lv {GameManager.Data.swordData.Items[0].currentLevel}";
                    break;
                case ItemData.ItemType.Bullet:
                    textLevel.text = $"Lv {GameManager.Data.bulletData.Items[0].currentLevel}";
                    break;
                case ItemData.ItemType.Electricity:
                    textLevel.text = $"Lv {GameManager.Data.electricityData.Items[0].currentLevel}";
                    break;
                case ItemData.ItemType.Explosion:
                    textLevel.text = $"Lv {GameManager.Data.explosionData.Items[0].currentLevel}";
                    break;
                case ItemData.ItemType.Fire:
                    textLevel.text = $"Lv {GameManager.Data.fireData.Items[0].currentLevel}";
                    break;
                case ItemData.ItemType.Armor:
                    textLevel.text = $"{GameManager.Data.currentPlayerData.armor}";
                    break;
                case ItemData.ItemType.MovementSpeed:
                    textLevel.text = $"{GameManager.Data.currentPlayerData.movementSpeed}";
                    break;
                case ItemData.ItemType.Damage:
                    textLevel.text = $"{GameManager.Data.currentPlayerData.damage}";
                    break;
                default:
                    textLevel.text = "default";
                    break;
            }
            yield return null;
        }
    }
}
