using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyTargetChecker : MonoBehaviour
{
    private Enemy myEnemy;
    private void Awake()
    {
        myEnemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagContainer.Player_Tag))
        {
            myEnemy.Target = other.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagContainer.Player_Tag))
        {
            myEnemy.Target = null;
        }
    }
}
