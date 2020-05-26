using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseActivator : MonoBehaviour
{
    protected Shootable tmpBullet;
    public abstract void StartPowerUpAction();
    public abstract void FinishPowerUpAction();
    private void Awake()
    {
        CustomEventSystem.EndGame += EndGame;
    }
    private void OnDisable()
    {
        CustomEventSystem.EndGame -= EndGame;
    }
    public virtual void EndGame()
    {

    }

}
