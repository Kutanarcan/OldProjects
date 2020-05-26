using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseChargeable : MonoBehaviour
{
    [SerializeField]
    protected Chargeable laserObj;
    [SerializeField]
    protected GameObject laserChargeSound;
    protected bool IsLaserActive;
    protected bool canPerformAttack;
    protected WaitForSeconds chargeDuration;
    private void Awake()
    {
        chargeDuration = new WaitForSeconds(laserObj.chargeDuration);
    }
    public void ChargeAttack()
    {
        if (IsLaserActive)
        {
            if (!canPerformAttack)
            {
                canPerformAttack = ChargeController.ChargePowerUp(laserObj);
                if (canPerformAttack)
                {
                    AudioManager.SetupAudio(laserChargeSound, 2f);
                    Perform();
                }
            }
        }
    }
    public abstract void Perform();
    public void SetLaserBool(bool laserActive)
    {
        //  ChargeController.ResetKeyTime();
        IsLaserActive = laserActive;
    }
}
