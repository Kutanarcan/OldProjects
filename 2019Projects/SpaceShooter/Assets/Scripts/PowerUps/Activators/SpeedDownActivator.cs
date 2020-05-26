using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownActivator : BaseActivator
{
    private PlayerMovement playerMovement;

    public override void StartPowerUpAction()
    {
        playerMovement = BasePlayer.Instance.PlayerMovement;
        playerMovement.MovementSpeed = 3.5f;
        Debug.Log("Your Speed Is Down");
    }
    public override void FinishPowerUpAction()
    {
        playerMovement.MovementSpeed = 7f;
        Debug.Log("Your Speed Is Back To Normal");
    }
}
