using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
    private static float keyDownTimer = 0f;
    public static bool ChargePowerUp(Chargeable powerUp)
    {
        Debug.Log(powerUp.canPowerCharge);
        if (powerUp.canPowerCharge)
        {
            keyDownTimer += Time.deltaTime;
            if (keyDownTimer >= powerUp.chargeTimer)
            {
                keyDownTimer = 0;
                return true;
            }
        }
        else
        {
            Debug.Log("Cannot Perform Attack");
        }
        return false;
    }
    public static void ResetKeyTime() { keyDownTimer = 0; }
}
