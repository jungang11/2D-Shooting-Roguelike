using System.Collections;
using UnityEngine;

public class LevelUpUI : PopUpUI
{
    // 레벨업시 나오는 팝업 UI. 아이템이나 능력 업그레이드 선택 가능.
    // LevelUpUI에 Grid Layout 적용하고 랜덤한 3가지 선택지를 활성화 해 선택할 수 있도록 구현
    Item[] items;
    int[] ranNum = new int[3];

    public CloseWeapon closeWeapon;

    protected override void Awake()
    {
        base.Awake();

        // Weapons

        buttons["Item1_Button"].onClick.AddListener(() => { ChoiceItem(0); });  // 기본 검
        buttons["Item2_Button"].onClick.AddListener(() => { ChoiceItem(1); });  // 총알
        buttons["Item3_Button"].onClick.AddListener(() => { ChoiceItem(2); });  // 전기
        buttons["Item4_Button"].onClick.AddListener(() => { ChoiceItem(3); });  // 폭발
        buttons["Item5_Button"].onClick.AddListener(() => { ChoiceItem(4); });  // 불길

        // Passive, Heal

        buttons["Item6_Button"].onClick.AddListener(() => { ChoiceItem(5); });  // 방어력
        buttons["Item7_Button"].onClick.AddListener(() => { ChoiceItem(6); });  // 이동속도
        buttons["Item8_Button"].onClick.AddListener(() => { ChoiceItem(7); });  // 공격력
        buttons["Item9_Button"].onClick.AddListener(() => { ChoiceItem(8); });  // 회복 아이템

        items = GetComponentsInChildren<Item>();
    }

    // 레벨이 올라 레벨업 UI가 활성화 될 경우 코루틴 실행
    private void OnEnable()
    {
        StartCoroutine(ShowItemsRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(ShowItemsRoutine());        
    }

    // 아이템 버튼마다 index에 따라 다르게 호출
    public void ChoiceItem(int index)
    {
        switch (index)
        {
            case 0: // 기본 검 선택
                items[index].level++;
                GameManager.Data.SwordLevelUP();
                Debug.Log($"검 강화 검 레벨{GameManager.Data.swordData.Items[0].currentLevel}");
                break;
            case 1: // 총알 선택
                items[index].level++;
                GameManager.Data.bulletData.Items[0].currentLevel++;
                Debug.Log("총알 강화");
                break;
            case 2: // 전기 선택
                items[index].level++;
                GameManager.Data.electricityData.Items[0].currentLevel++;
                Debug.Log("전기 강화");
                break;
            case 3: // 폭발 선택
                items[index].level++;
                GameManager.Data.explosionData.Items[0].currentLevel++;
                Debug.Log("폭발 강화");
                break;
            case 4: // 불길 선택
                items[index].level++;
                GameManager.Data.fireData.Items[0].currentLevel++;
                Debug.Log("불길 강화");
                break;
            case 5: // 방어력 선택
                items[index].level++;
                playerData.armor += 0.5f;
                Debug.Log("방어력 증가");
                break;
            case 6: // 이동속도 선택
                items[index].level++;
                playerData.movementSpeed += 2f;
                Debug.Log("이동속도 증가");
                break;
            case 7: // 공격력 선택
                items[index].level++;
                playerData.damage += 2f;
                Debug.Log("공격력 증가");
                break;
            case 8: // 회복 아이템 (만렙)
                playerData.hp += 5f;
                Debug.Log("회복");
                break;
        }

        // 선택 후 UI 닫기
        GameManager.UI.ClosePopUpUI();
    }

    // 선택지를 나타내는 코루틴
    IEnumerator ShowItemsRoutine()
    {
        // 모든 아이템 비활성화
        for(int i=0 ; i< items.Length; i++)
        {
            items[i].gameObject.SetActive(false);
        }

        // 비활성화된 아이템들 중 랜덤한 3개 아이템 활성화
        while (true)
        {
            ranNum[0] = Random.Range(0, items.Length-1);
            ranNum[1] = Random.Range(0, items.Length-1);
            ranNum[2] = Random.Range(0, items.Length-1);

            // 중복 제거
            if (ranNum[0] != ranNum[1] && ranNum[0] != ranNum[2] && ranNum[1] != ranNum[2])
                break;
        }

        for (int i = 0; i < ranNum.Length; i++)
        {
            Item showItem = items[ranNum[i]];

            // 만렙 아이템의 경우 아이템 대신 회복 아이템(소비아이템)이 활성화 되도록 함
            if (showItem.level == showItem.data.Items[0].maxLevel)
            {
                items[8].gameObject.SetActive(true);
            }
            else
            {
                showItem.gameObject.SetActive(true);
            }
        }
        yield return null;
    }
}