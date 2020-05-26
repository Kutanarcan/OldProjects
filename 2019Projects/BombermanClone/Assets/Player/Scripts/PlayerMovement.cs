using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField]
    private PlayerMovementData movementData;
    private Vector2 moveAxis;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MoveAxisSetting();
    }
    private void MoveAxisSetting()
    {
        moveAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAxis.Normalize();

        movementData.HorizontalAxis = moveAxis.x;
        movementData.VerticalAxis = moveAxis.y;
    }
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveAxis * movementData.MovementSpeed * Time.fixedDeltaTime);
    }
}
