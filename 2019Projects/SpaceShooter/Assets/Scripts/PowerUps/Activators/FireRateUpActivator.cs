using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpActivator : BaseActivator
{
    private PlayerShoot playerShoot;
    private WaitForSeconds waitTime;
    public override void StartPowerUpAction()
    {
        playerShoot = BasePlayer.Instance.PlayerShoot;
        waitTime = new WaitForSeconds(playerShoot.ShootTimer / 2);
        playerShoot.WaitTime = waitTime;
        Debug.Log("Fire Rate Incareased");
    }
    public override void FinishPowerUpAction()
    {
        waitTime = new WaitForSeconds(playerShoot.ShootTimer);
        playerShoot.WaitTime = waitTime;
        Debug.Log("Fire Rate Decreased");
    }
}
