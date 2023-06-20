using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int level = 0;
    public int kill;
    public int exp;
    public int[] nextExp = { 0, 10, 20, 30 };

    public void GetExp()
    {
        exp++;
        if(exp >= nextExp[level])
        {
            // TODO : Levelup
            level++;
            exp = 0;
        }
    }
}
