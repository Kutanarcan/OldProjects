using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float enemyMoveSpeed;
    private void FixedUpdate()
    {
        EnemyMove();
    }
    private void EnemyMove()
    {
        transform.Translate(-transform.up * Time.deltaTime * enemyMoveSpeed);
    }
}
