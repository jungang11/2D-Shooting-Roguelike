using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class LevelUpUI : PopUpUI
{
    // �������� ������ �˾� UI. �������̳� �ɷ� ���׷��̵� ���� ����.
    // LevelUpUI�� Grid Layout �����ϰ� ������ 3���� �������� Ȱ��ȭ �� ������ �� �ֵ��� ����

    Item[] items;
    int[] ranNum = new int[3];

    protected override void Awake()
    {
        base.Awake();

        buttons["Item1_Button"].onClick.AddListener(() => { ChoiceItem(0); });  // �⺻ ��
        buttons["Item2_Button"].onClick.AddListener(() => { ChoiceItem(1); });  // �Ѿ�
        buttons["Item3_Button"].onClick.AddListener(() => { ChoiceItem(2); });  // ����
        buttons["Item4_Button"].onClick.AddListener(() => { ChoiceItem(3); });  // ����
        buttons["Item5_Button"].onClick.AddListener(() => { ChoiceItem(4); });  // �̵��ӵ�
        buttons["Item6_Button"].onClick.AddListener(() => { ChoiceItem(5); });  // ���ݷ�
        buttons["Item7_Button"].onClick.AddListener(() => { ChoiceItem(6); });  // ȸ�� ������

        items = GetComponentsInChildren<Item>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShowItemsRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void ChoiceItem(int index)
    {
        GameManager.UI.ClosePopUpUI();

        switch (index)
        {
            case 0: // �⺻ ��
                GameManager.Data.playerData.movementSpeed += 1f;
                break;
            case 1: // �Ѿ�
                GameManager.Data.playerData.attack += 1f;
                break;
            case 2: // ����
                GameManager.Data.playerData.criticalRate += 1f;
                break;
            case 3: // ����
                GameManager.Data.playerData.armor += 1f;
                break;
            case 4: // �̵��ӵ�
                GameManager.Data.playerData.movementSpeed += 1f;
                break;
            case 5: // ���ݷ�
                GameManager.Data.playerData.attack += 1f;
                break;
            case 6: // ȸ�� ������ (����)
                GameManager.Data.playerData.hp += 1f;
                break;
        }
    }

    IEnumerator ShowItemsRoutine()
    {
        // 1. ��� ������ ��Ȱ��ȭ
        for(int i=0 ; i< items.Length; i++)
        {
            items[i].gameObject.SetActive(false);
        }

        // 2. ��Ȱ��ȭ�� �����۵� �� ������ 3�� ������ Ȱ��ȭ
        while (true)
        {
            ranNum[0] = Random.Range(0, items.Length-1);
            ranNum[1] = Random.Range(0, items.Length-1);
            ranNum[2] = Random.Range(0, items.Length-1);

            // �ߺ� ����
            if (ranNum[0] != ranNum[1] && ranNum[0] != ranNum[2] && ranNum[1] != ranNum[2])
                break;
        }

        for (int i = 0; i < ranNum.Length; i++)
        {
            Item showItem = items[ranNum[i]];

            // 3. ���� �������� ��� �Һ���������� ��ü
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
