using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeBulletActivator : BaseActivator
{
    private ShootController shootController;
    [SerializeField]
    private Shootable threeBullet;
    public override void StartPowerUpAction()
    {
        shootController = BasePlayer.Instance.shootController;
       // threeBullet.ActivateShotPoints(shootController.shotPoints);
        Debug.Log("Three Bullet Activated");
    }
    public override void FinishPowerUpAction()
    {
      //  threeBullet.DeActivateShotPoints();
        Debug.Log("Three Bullet Deactivated");
    }
}
