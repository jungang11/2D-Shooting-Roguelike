using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUI : PopUpUI
{
    public PlayerData basePlayerData;
    public PlayerData currentPlayerData;

    protected override void Awake()
    {
        base.Awake();

        buttons["CloseButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["Item1Button"].onClick.AddListener(() => { ChoiceItem(1); });
        buttons["Item2Button"].onClick.AddListener(() => { ChoiceItem(2); });
        buttons["Item3Button"].onClick.AddListener(() => { ChoiceItem(3); });
        buttons["Item4Button"].onClick.AddListener(() => { ChoiceItem(4); });
        buttons["Item5Button"].onClick.AddListener(() => { ChoiceItem(5); });
        buttons["Item6Button"].onClick.AddListener(() => { ChoiceItem(6); });

        basePlayerData = GameManager.Data.basePlayerData;
        currentPlayerData = GameManager.Data.currentPlayerData;
    }

    void ChoiceItem(int index)
    {
        switch (index)
        {
            case 1: // Damage
                basePlayerData.damage += 0.5f;
                currentPlayerData.damage += 0.5f;
                texts["Item1NameText"].text = $"공격력 {currentPlayerData.damage}";
                break;
            case 2: // Armor
                basePlayerData.armor += 0.2f;
                currentPlayerData.armor += 0.2f;
                texts["Item2NameText"].text = $"방어력 {currentPlayerData.armor}";
                break;
            case 3: // Speed
                basePlayerData.movementSpeed += 0.2f;
                currentPlayerData.movementSpeed += 0.2f;
                texts["Item3NameText"].text = $"이동속도 {currentPlayerData.movementSpeed}";
                break;
            case 4: // AttackSpeed (Cooldown)
                basePlayerData.coolTime += 0.2f;
                currentPlayerData.coolTime += 0.2f;
                texts["Item4NameText"].text = $"공격속도 {currentPlayerData.coolTime}";
                break;
            case 5: // MaxHp
                basePlayerData.hp += 0.5f;
                currentPlayerData.hp += 0.5f;
                texts["Item5NameText"].text = $"최대 체력 {currentPlayerData.hp}";
                break;
            case 6: // Area
                basePlayerData.area += 0.5f;
                currentPlayerData.area += 0.5f;
                texts["Item6NameText"].text = $"공격범위 {currentPlayerData.area}";
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
}
