using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField]
    private float objMoveSpeed;
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(-transform.up * Time.deltaTime * objMoveSpeed);
    }
}
