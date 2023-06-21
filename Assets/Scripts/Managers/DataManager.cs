using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public int level = 0;
    public int kill;
    public float exp;
    public float[] nextExp = { 5f, 10f, 20f, 30f, 40f, 50f, 60f, 70f, 80f, 90f, 100f };

    public void GetExp()
    {
        exp++;
        if(level > nextExp.Length)
        {
            return;
        }

        if (exp >= nextExp[level])
        {
            // TODO : Levelup
            level++;
            exp = 0;
        }
    }
}
