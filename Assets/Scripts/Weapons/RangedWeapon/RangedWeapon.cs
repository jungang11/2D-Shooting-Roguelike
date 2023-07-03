using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

// 원거리 무기들 
public class RangedWeapon : Weapon
{
    public PlayerController player;
    public Vector3 targetPoint;
    public Vector3 dirVec;

    protected override void Awake()
    {
        base.Awake();

        player = GetComponentInParent<PlayerController>();
    }
}
