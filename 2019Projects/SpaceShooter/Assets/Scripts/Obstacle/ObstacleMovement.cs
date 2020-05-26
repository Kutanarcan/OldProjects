using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField]
    private float obstacleMoveSpeed;
    private void FixedUpdate()
    {
        ObstacleMove();
    }
    private void ObstacleMove()
    {
        transform.Translate(-transform.up * Time.deltaTime * obstacleMoveSpeed);
    }
}
