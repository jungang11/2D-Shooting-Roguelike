using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelUpUI : PopUpUI
{
    // 레벨업시 나오는 팝업 UI. 아이템이나 능력 업그레이드 선택 가능.
    // LevelUpUI에 Grid Layout 적용하고 랜덤한 3가지 선택지를 활성화 해 선택할 수 있도록 구현

    Item[] items;
    int[] ranNum = new int[3];

    protected override void Awake()
    {
        base.Awake();

        buttons["Item1_Button"].onClick.AddListener(() => { ChoiceItem(0); });  // 기본 검
        buttons["Item2_Button"].onClick.AddListener(() => { ChoiceItem(1); });  // 총알
        buttons["Item3_Button"].onClick.AddListener(() => { ChoiceItem(2); });  // 전기
        buttons["Item4_Button"].onClick.AddListener(() => { ChoiceItem(3); });  // 방어력
        buttons["Item5_Button"].onClick.AddListener(() => { ChoiceItem(4); });  // 이동속도
        buttons["Item6_Button"].onClick.AddListener(() => { ChoiceItem(5); });  // 공격력
        buttons["Item7_Button"].onClick.AddListener(() => { ChoiceItem(6); });  // 회복 아이템

        items = GetComponentsInChildren<Item>();
    }

    private void Start()
    {
        StartCoroutine(ShowItemsRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    // 아이템 버튼마다 index에 따라 다르게 호출
    public void ChoiceItem(int index)
    {
        GameManager.UI.ClosePopUpUI();

        switch (index)
        {
            case 0: // 기본 검
                items[index].level++;
                Debug.Log("검 강화");
                // TODO : 검 강화
                break;
            case 1: // 총알
                items[index].level++;
                Debug.Log("총알 강화");
                break;
            case 2: // 전기
                items[index].level++;
                Debug.Log("전기 강화");
                break;
            case 3: // 방어력
                items[index].level++;
                Debug.Log("방어력 증가");
                break;
            case 4: // 이동속도
                items[index].level++;
                GameManager.Data.currentPlayerData.movementSpeed += 1f;
                Debug.Log("이동속도 증가");
                break;
            case 5: // 공격력
                items[index].level++;
                GameManager.Data.currentPlayerData.attack += 1f;
                Debug.Log("공격력 증가");
                break;
            case 6: // 회복 아이템 (만렙)
                GameManager.Data.currentPlayerData.hp += 1f;
                Debug.Log("회복");
                break;
        }
    }

    IEnumerator ShowItemsRoutine()
    {
        // 1. 모든 아이템 비활성화
        for(int i=0 ; i< items.Length; i++)
        {
            items[i].gameObject.SetActive(false);
        }

        // 2. 비활성화된 아이템들 중 랜덤한 3개 아이템 활성화
        while (true)
        {
            ranNum[0] = Random.Range(0, items.Length);
            ranNum[1] = Random.Range(0, items.Length);
            ranNum[2] = Random.Range(0, items.Length);
            Debug.Log($"{ranNum[0]} {ranNum[1]} {ranNum[2]}");

            // 중복 제거
            if (ranNum[0] != ranNum[1] && ranNum[0] != ranNum[2] && ranNum[1] != ranNum[2])
                break;
        }

        for (int i = 0; i < ranNum.Length; i++)
        {
            Item showItem = items[ranNum[i]];

            // 3. 만렙 아이템의 경우 소비아이템으로 대체
            if (showItem.level == showItem.data.Items[0].damages.Length)
            {
                items[6].gameObject.SetActive(true);
            }
            else
            {
                showItem.gameObject.SetActive(true);
            }
        }
        yield return null;
    }
}