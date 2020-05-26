using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedUpActivator : BaseActivator
{
    private PlayerBullet playerBullet;
    public override void StartPowerUpAction()
    {
        playerBullet = BasePlayer.Instance.PlayerShoot.BulletPrefab.GetComponent<PlayerBullet>();
        playerBullet.BulletSpeed *= 2;
        Debug.Log("Bullet Speed Is Increased");
    }
    public override void FinishPowerUpAction()
    {
        playerBullet.BulletSpeed /= 2;
        Debug.Log("Bullet Speed Is Decreased");
    }
}
