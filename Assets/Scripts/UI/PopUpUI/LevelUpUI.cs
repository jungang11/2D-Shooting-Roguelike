using System.Collections;
using UnityEngine;

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

    private void Start()
    {
        StartCoroutine(ShowItemsRoutine());
    }

    // ������ ��ư���� index�� ���� �ٸ��� ȣ��
    public void ChoiceItem(int index)
    {
        GameManager.UI.ClosePopUpUI();

        switch (index)
        {
            case 0: // �⺻ ��
                items[index].level++;
                Debug.Log("�� ��ȭ");
                break;
            case 1: // �Ѿ�
                items[index].level++;
                Debug.Log("�Ѿ� ��ȭ");
                break;
            case 2: // ����
                items[index].level++;
                Debug.Log("���� ��ȭ");
                break;
            case 3: // ����
                items[index].level++;
                GameManager.Data.currentPlayerData.armor += 2f;
                Debug.Log("���� ����");
                break;
            case 4: // �̵��ӵ�
                items[index].level++;
                GameManager.Data.currentPlayerData.movementSpeed += 2f;
                Debug.Log("�̵��ӵ� ����");
                break;
            case 5: // ���ݷ�
                items[index].level++;
                GameManager.Data.currentPlayerData.damage += 2f;
                Debug.Log("���ݷ� ����");
                break;
            case 6: // ȸ�� ������ (����)
                GameManager.Data.currentPlayerData.hp += 5f;
                Debug.Log("ȸ��");
                break;
        }
    }

    IEnumerator ShowItemsRoutine()
    {
        // ��� ������ ��Ȱ��ȭ
        for(int i=0 ; i< items.Length; i++)
        {
            items[i].gameObject.SetActive(false);
        }

        // ��Ȱ��ȭ�� �����۵� �� ������ 3�� ������ Ȱ��ȭ
        while (true)
        {
            ranNum[0] = Random.Range(0, items.Length);
            ranNum[1] = Random.Range(0, items.Length);
            ranNum[2] = Random.Range(0, items.Length);
            Debug.Log($"{ranNum[0]} {ranNum[1]} {ranNum[2]}");

            // �ߺ� ����
            if (ranNum[0] != ranNum[1] && ranNum[0] != ranNum[2] && ranNum[1] != ranNum[2])
                break;
        }

        for (int i = 0; i < ranNum.Length; i++)
        {
            Item showItem = items[ranNum[i]];

            // ���� �������� ��� ������ ��� ȸ�� ������(�Һ������)�� Ȱ��ȭ �ǵ��� ��
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