using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected PlayerData playerData;

    protected virtual void Awake()
    {
        playerData = GameManager.Data.currentPlayerData;
    }
}