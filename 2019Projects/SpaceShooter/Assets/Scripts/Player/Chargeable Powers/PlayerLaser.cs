using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : PlayerBaseChargeable
{
    [SerializeField]
    private LaserTrigger laserTrigger;
    IEnumerator PerformLaser()
    {
        laserTrigger.gameObject.SetActive(true);
        Debug.Log("Performing attack");
        yield return chargeDuration;
        laserTrigger.gameObject.SetActive(false);
        canPerformAttack = false;
    }
    public void StopMyCoroutine()
    {
        StopCoroutine(PerformLaser());
        laserTrigger.gameObject.SetActive(false);
        canPerformAttack = false;
    }
    public override void Perform()
    {
        StartCoroutine(PerformLaser());
    }
}
