using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourBulletActivator : BaseActivator
{
    private ShootController shootController;
    [SerializeField]
    private Shootable fourBullet;
    public override void StartPowerUpAction()
    {        
        shootController = BasePlayer.Instance.shootController;
     //   fourBullet.ActivateShotPoints(shootController.shotPoints);
        Debug.Log("Four Bullet Activated");
    }
    public override void FinishPowerUpAction()
    {
      //  fourBullet.DeActivateShotPoints();
        Debug.Log("Four Bullet Deactivated");
    }  
}
