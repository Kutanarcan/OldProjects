using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPowerUps : MonoBehaviour
{
    public bool CanBreak { get => canBreak; set => canBreak = value; }
    [SerializeField]
    private GameObject powerUpPanel;
    [SerializeField]
    private GameObject progressBarPrefab;
    [SerializeField]
    private PowerUpDisplayData leftOverData;
    private List<PowerUp> powerUps;
    private bool canBreak;
    private void Awake()
    {
        powerUps = new List<PowerUp>();
        CustomEventSystem.PickedPowerUp += InitializePowerUpDisplayer;
    }
    private void InitializePowerUpDisplayer(PowerUp powerup)
    {
        StartCoroutine(Progress(powerup));
    }
    IEnumerator Progress(PowerUp powerup)
    {
        //TODO: Some Bugs appear on when i picked up the power up. Look at this class.
        powerup.leftOverTime = powerup.duration;
        GameObject tmp = Instantiate(progressBarPrefab);
        tmp.transform.SetParent(powerUpPanel.transform);
        Image powerUpBar = tmp.gameObject.transform.GetChild(0).GetComponent<Image>();
        Image icon = tmp.gameObject.transform.GetChild(1).GetChild(0).GetComponent<Image>();
        icon.sprite = powerup.icon;
        float rate = (1.0f / (powerup.duration + leftOverData.leftOverTime));
        float progress = 1.0f;
        while (progress >= 0.0f)
        {
            powerUpBar.fillAmount = Mathf.Lerp(0, 1, progress);
            progress -= rate * Time.deltaTime;
            yield return null;
            if (canBreak)
            {
                break;
            }
        }
        canBreak = false;
        Destroy(tmp.gameObject);
    }
}

