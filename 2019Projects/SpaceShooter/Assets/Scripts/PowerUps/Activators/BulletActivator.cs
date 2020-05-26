using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletActivator : BaseActivator
{
    private static Shootable bullet;
    private PlayerShoot playerShoot;
    [SerializeField]
    private BulletQueue BulletQueue;

    private ShootController shootController => BasePlayer.Instance.shootController;
    public override void StartPowerUpAction()
    {
        if (BulletQueue.shootables.Count > 0)
        {
            DeActivatePoints(4);
        }
        playerShoot = BasePlayer.Instance.PlayerShoot;
        playerShoot.ChangeThePrefab(bullet.playerBulletPrefab);
        if (bullet.type == ShootType.Two)
        {
            ActivatePoints(2);
        }
        else if (bullet.type == ShootType.Three)
        {
            ActivatePoints(3);
        }
        else if (bullet.type == ShootType.Four)
        {
            ActivatePoints(4);
        }
        BulletQueue.shootables.Enqueue(bullet);
    }
    public override void FinishPowerUpAction()
    {
        if (BulletQueue.shootables.Count <= 1)
        {
            playerShoot.ChangeThePrefab(bullet.OriginBulletPrefab);
            DeActivatePoints(4);
        }
        BulletQueue.shootables.Dequeue();
        if (BulletQueue.shootables.Count > 0)
        {
            DeActivatePoints(4);

            for (int i = 0; i < BulletQueue.shootables.Peek().index; i++)
            {
                shootController.shotPoints[i].gameObject.SetActive(true);
                shootController.shotPoints[i].transform.localPosition = BulletQueue.shootables.Peek().points[i];
            }
        }
    }
    private void ActivatePoints(int index)
    {
        for (int i = 1; i < index; i++)
        {
            shootController.shotPoints[i].gameObject.SetActive(true);
        }
        SetPoints(index);
    }
    private void DeActivatePoints(int index)
    {
        for (int i = 1; i < index; i++)
        {
            shootController.shotPoints[i].gameObject.SetActive(false);
        }
        ResetPoint();
    }
    public void SetPoints(int index)
    {
        for (int i = 0; i < index; i++)
        {
            shootController.shotPoints[i].transform.localPosition = bullet.points[i];
        }
    }
    public void ResetPoint()
    {
        shootController.shotPoints[0].transform.localPosition = bullet.originPoint;
    }
    public static void SetBullet(Shootable shootable)
    {
        bullet = shootable;
    }
    public override void EndGame()
    {
        BulletQueue.shootables.Clear();
    }
}
