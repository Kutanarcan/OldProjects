using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerShoot playerShoot;
    private PlayerLaser playerChargePower;
    private bool shootInput;
    private void Awake()
    {
        playerShoot = GetComponent<PlayerShoot>();
        playerChargePower = GetComponent<PlayerLaser>();
    }
    private void Update()
    {
        HandlePlayerInput();
    }
    private void HandlePlayerInput()
    {
        ShootBulletInput();
        ShootLaserInput();
    }
    private void ShootBulletInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerShoot.Shoot();
        }
    }
    private void ShootLaserInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerChargePower.SetLaserBool(true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerChargePower.ChargeAttack();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerChargePower.SetLaserBool(false);
            playerChargePower.StopMyCoroutine();
        }        
    }
}
