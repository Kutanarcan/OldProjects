using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpActivator : BaseActivator
{
    private PlayerMovement playerMovement;
    public override void StartPowerUpAction()
    {
        playerMovement = BasePlayer.Instance.PlayerMovement;
        playerMovement.MovementSpeed = 14f;
        Debug.Log("Speeding Up");
    }
    public override void FinishPowerUpAction()
    {
        playerMovement.MovementSpeed = 7f;
        Debug.Log("Speeding Up is Finished");
    }
}
