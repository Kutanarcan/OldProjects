using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Power Up", menuName = "ScriptableObjects/PowerUp/Normal")]
public class PowerUp : ScriptableObject
{
    public float duration;
    public Sprite icon;
    public string powerupName;
    public BaseActivator powerUpActivator;
    public float leftOverTime;
    public void ActivatePowerUp()
    {
        powerUpActivator.StartPowerUpAction();
    }
    public void DeActivatePowerUp()
    {
        powerUpActivator.FinishPowerUpAction();
    }
}
