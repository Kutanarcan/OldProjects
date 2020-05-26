using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoBulletActivator : BaseActivator
{
    private ShootController shootController;
    [SerializeField]
    private Shootable twoBullet;

    public override void StartPowerUpAction()
    {
        shootController=BasePlayer.Instance.shootController;
     //   twoBullet.ActivateShotPoints(shootController.shotPoints);
        Debug.Log("Two Bullet Activated");
    }
    public override void FinishPowerUpAction()
    {
     //   twoBullet.DeActivateShotPoints();
        Debug.Log("Two Bullet Deactivated");
    }
    
}
