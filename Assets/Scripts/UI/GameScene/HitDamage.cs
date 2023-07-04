using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitDamage : MonoBehaviour
{
    [SerializeField] MonsterController monster;

    public TMP_Text damageText;
    public Animator anim;

    private void OnEnable()
    {
        damageText.text = "";
        damageText.fontSize = 0.6f;
    }

    public void PrintDamage(float damage)
    {
        anim.SetTrigger("TakeHit");
        damageText.text = $"{damage}";
    }
}
