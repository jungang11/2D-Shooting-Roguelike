using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public LayerMask enemyMask;

    public UnityEvent<MonsterController> OnInRangeEnemy;
    public UnityEvent<MonsterController> OnOutRangeEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyMask.IsContain(collision.gameObject.layer))
        {
            MonsterController enemy = collision.GetComponent<MonsterController>();
            OnInRangeEnemy?.Invoke(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemyMask.IsContain(collision.gameObject.layer))
        {
            MonsterController enemy = collision.GetComponent<MonsterController>();
            OnOutRangeEnemy?.Invoke(enemy);
        }
    }
}
