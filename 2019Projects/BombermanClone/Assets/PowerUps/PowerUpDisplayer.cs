using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUpDisplayPrefab;

    private Image powerUpIcon;
    private void OnEnable()
    {
        CustomEventSystem.OnPickedPowerUp += DisplayPowerUp;
    }
    private void DisplayPowerUp(PowerUp powerup)
    {
        GameObject tmp = Instantiate(powerUpDisplayPrefab);

        tmp.transform.SetParent(this.transform);
        powerUpIcon = tmp.GetComponent<Image>();
        tmp.transform.localScale = new Vector3(1, 1, 1);

        powerUpIcon.sprite = powerup.Icon;
    }
    private void OnDisable()
    {
        CustomEventSystem.OnPickedPowerUp -= DisplayPowerUp;
    }
}
