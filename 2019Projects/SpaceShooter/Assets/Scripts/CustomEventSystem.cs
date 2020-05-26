using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomEventSystem
{
    public static event System.Action NewGame;
    public static event System.Action<float> TakeDamage;
    public static event System.Action<int> ScoreCount;
    public static event System.Action EndGame;
    public static event System.Action<PowerUp> PickedPowerUp;
    public static event System.Action<string> PowerUpLeftTime;
    public static event System.Action<Shootable> ShootablePickedUped;
    public static void StartNewGameAction()
    {
        NewGame?.Invoke();
    }
    public static void TakeDamageAction(float amount)
    {
        TakeDamage?.Invoke(amount);
    }
    public static void ScoreCountAction(int amount)
    {
        ScoreCount?.Invoke(amount);
    }
    public static void EndGameAction()
    {
        EndGame?.Invoke();
    }
    public static void PickedUpPowerUpAction(PowerUp powerUp)
    {
        PickedPowerUp?.Invoke(powerUp);
    }
    public static void PowerUpLeftTimeAction(string value)
    {
        PowerUpLeftTime?.Invoke(value);
    }
    public static void ShootablePickedUpedAction(Shootable powerUp)
    {
        ShootablePickedUped?.Invoke(powerUp);
    }
}
