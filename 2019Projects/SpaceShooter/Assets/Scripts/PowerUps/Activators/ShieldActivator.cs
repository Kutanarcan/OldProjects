using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivator : BaseActivator
{
    BasePlayer basePlayer;
    public override void StartPowerUpAction()
    {
        basePlayer = BasePlayer.Instance;
        SetShieldProperties(true);
        Debug.Log("Shield Started.");
    }
    public override void FinishPowerUpAction()
    {
        //Sometimes Shield Don't get Deactiveted
        //TODO: Find the bug. Is problem here or the PowerUpController?
        SetShieldProperties(false);
        Debug.Log("Sheild Ended");
    }
    private void SetShieldProperties(bool value)
    {
        basePlayer.IsShieldActive = value;
        basePlayer.Shield.gameObject.SetActive(value);
    }
}
