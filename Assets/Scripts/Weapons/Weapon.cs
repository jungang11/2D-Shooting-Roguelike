using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected List<MonsterController> monsterList;  // ������ ���� ���� ����Ʈ

    protected virtual void Awake()
    {
        monsterList = new List<MonsterController>();
    }

    public void AddEnemy(MonsterController monster)
    {
        monsterList.Add(monster);
    }

    public void RemoveEnemy(MonsterController monster)
    {
        monsterList.Remove(monster);
    }
}
