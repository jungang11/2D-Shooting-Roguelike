using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : CloseWeapon
{
    public float per;

    public void Setting(float damage, float per)
    {
        this.damage = damage;
        this.per = per;
    }
}
