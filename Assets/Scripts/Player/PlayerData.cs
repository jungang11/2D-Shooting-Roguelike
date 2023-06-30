using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public int   level;                 // ����
    public int   kill;                  // ų ��
    public float exp;                   // ���� ����ġ
    public float nextExp;               // ���� ���� ����ġ

    public float hp;                    // ü��
    public float hpRecovery;            // ü�� ȸ����
    public float armor;                 // ����
    public float movementSpeed;         // �̵��ӵ�

    public float damage;                // ���ݷ�
    public float criticalRate;          // ũ��Ƽ�� Ȯ��
    public float criticalMultiplier;    // ũ��Ƽ�� ������ ����

    public float area;                  // ���� ����
    public float projectileSpeed;       // ���� �ӵ� (�߻�ü)
    public float duration;              // ���� ���ӽð� (���Ÿ�)
    public float coolTime;              // ��Ÿ��
    public float magnet;                // �ڼ�

    public float luck;                  // ���(����)
    public float expMultiplier;         // ����ġ ����
    public float goldMultiplier;        // ��� ����(����)

    // ������ �� �ö󰡴� �ɷ�ġ -> �������
    public StatsIncreasePerLevel statsIncreasePerLevel;

    [Serializable]
    public class StatsIncreasePerLevel
    {
        public float hp;
        public float hpRecovery;
        public float armor;
        public float attack;
    }
}