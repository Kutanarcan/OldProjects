using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField]
    private DisplayPowerUps powerUpDisplayer;
    [SerializeField]
    private GameObject[] powerUpSounds;
    [SerializeField]
    private GameObject powerUpFinishedSound;
    [SerializeField]
    private PowerUpDisplayData leftOverData;
    WaitForSeconds duration;
    Dictionary<string, PowerUp> powerups = new Dictionary<string, PowerUp>();
    Dictionary<string, PowerUp> registeredPowerUp = new Dictionary<string, PowerUp>();
    private List<float> leftOverTimes;
    private PowerUp powerUp;
    private float leftOverTime;
    private Coroutine tmp;
    private bool canBreak;
    public float DisplayTimer { get; set; }
    public float LeftOverTime { get => leftOverTime; set => leftOverTime = value; }
    private void Awake()
    {
        CustomEventSystem.PickedPowerUp += InitializePowerUp;
        CustomEventSystem.PowerUpLeftTime += CalculateLeftOverTime;
    }
    public void InitializePowerUp(PowerUp powerUp)
    {
        //TODO: Some Bugs appear on when i picked up the power up. Look at this class.
        AudioManager.SetupAudio(powerUpSounds, 1f);
        this.powerUp = powerUp;
        PowerUpSetup();
        duration = new WaitForSeconds(powerUp.duration);
        PowerUpDurationAdder(powerUp.powerupName);
    }
    #region DictionarySetup
    private void PowerUpSetup()
    {
        DictionaryAdder(powerups);
    }
    private void AddPowerUp(Dictionary<string, PowerUp> dictionary)
    {
        dictionary.Add(powerUp.powerupName, powerUp);
    }
    private void DictionaryAdder(Dictionary<string, PowerUp> dictionary)
    {
        if (!dictionary.ContainsKey(powerUp.powerupName))
        {
            AddPowerUp(dictionary);
        }
    }
    private void DictionaryRemover(Dictionary<string, PowerUp> dictionary, string key)
    {
        if (dictionary.ContainsKey(powerUp.powerupName))
        {
            dictionary.Remove(key);
        }
    }
    private void PowerUpDurationAdder(string key)
    {
        if (registeredPowerUp.ContainsKey(key))
        {
            leftOverData.leftOverTime = LeftOverTime;
            powerUpDisplayer.CanBreak = true;
            StopCoroutine(tmp);
            registeredPowerUp[key].DeActivatePowerUp();
            duration = new WaitForSeconds(registeredPowerUp[key].duration + leftOverTime);
        }
        if (!powerUpDisplayer.CanBreak)
            leftOverData.leftOverTime = 0;
        tmp = StartCoroutine(DoPowerUpEffectCoroutine(key));
    }
    #region LeftOverTime

    private void CalculateLeftOverTime(string powerUpName)
    {
        leftOverTime = powerups[powerUpName].duration;
        float rate = 1.0f / powerups[powerUpName].duration;
        float progress = 1.0f;

        while (progress >= 0.1f)
        {
            progress -= rate * Time.deltaTime;
            leftOverTime -= Time.deltaTime / powerups[powerUpName].duration;
        }
    }
    #endregion
    #endregion
    IEnumerator DoPowerUpEffectCoroutine(string powerUpName)
    {
        powerups[powerUpName].ActivatePowerUp();
        DictionaryAdder(registeredPowerUp);
        CustomEventSystem.PowerUpLeftTimeAction(powerUpName);
        yield return duration;
        powerups[powerUpName].DeActivatePowerUp();
        DictionaryRemover(registeredPowerUp, powerUpName);
        AudioManager.SetupAudio(powerUpFinishedSound, 1f);
    }
}
