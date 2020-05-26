using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivator : BaseActivator, IChargeable
{
    [SerializeField]
    private Chargeable powerUp;
    public override void EndGame()
    {
        powerUp.canPowerCharge = false;
    }
    public override void StartPowerUpAction()
    {
        SetChargeableBoolean(true);
        Debug.Log("Lazer Can Charge");
    }
    public override void FinishPowerUpAction()
    {
        SetChargeableBoolean(false);
        Debug.Log("Lazer Power Up is Finished");
    }
    public void SetChargeableBoolean(bool canPerform)
    {
        powerUp.canPowerCharge = canPerform;
    }
}
