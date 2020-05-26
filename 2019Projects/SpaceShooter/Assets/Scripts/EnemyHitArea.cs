using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = (Enemy)other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Destroy(enemy.gameObject);
            CustomEventSystem.TakeDamageAction(1f);
        }
    }
}
