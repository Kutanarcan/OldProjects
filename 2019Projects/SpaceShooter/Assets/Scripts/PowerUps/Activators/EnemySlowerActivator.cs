using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowerActivator : BaseActivator
{
    public override void StartPowerUpAction()
    {
        Debug.Log("Enemies Slowed");
    }
    public override void FinishPowerUpAction()
    {
        Debug.Log("Enemies Speed Back To Normal");
    }
}
