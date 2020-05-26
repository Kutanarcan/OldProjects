using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Vector2 playerMovement;
    [SerializeField]
    private float movementSpeed;
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PlayerMovementSettings();
    }
    private void FixedUpdate()
    {
        MoveThePlayer();
    }
    private void PlayerMovementSettings()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
    }
    private void MoveThePlayer()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + playerMovement * movementSpeed * Time.fixedDeltaTime);
    }
}
