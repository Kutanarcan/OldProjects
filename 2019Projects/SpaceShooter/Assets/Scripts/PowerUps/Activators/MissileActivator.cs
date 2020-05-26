using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileActivator : BaseActivator, IChargeable
{
    [SerializeField]
    private Chargeable powerup;
    private void Awake()
    {
        //  powerup.canPowerCharge = false;
    }
    public override void StartPowerUpAction()
    {
        SetChargeableBoolean(true);
        Debug.Log("Missile Picked Up");
    }
    public override void FinishPowerUpAction()
    {
        SetChargeableBoolean(false);
        Debug.Log("Missile Dropped");
    }

    public void SetChargeableBoolean(bool canPerform)
    {
        powerup.canPowerCharge = canPerform;
    }


}
