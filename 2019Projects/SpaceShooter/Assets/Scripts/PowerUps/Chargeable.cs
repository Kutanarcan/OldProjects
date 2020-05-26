using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chargeable Power Up", menuName = "ScriptableObjects/PowerUp/Chargeable")]
public class Chargeable : PowerUp
{
    public float chargeDuration;
    public float chargeTimer;
    public bool canPowerCharge = false;
    private void OnEnable()
    {
        canPowerCharge = false;
    }
}
