using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour, IDamagable
{
    [SerializeField]
    private PlayerOrigin PlayerOrigin;
    public void ApplyDamage()
    {
        CustomEventSystem.PlayerDeadAction();
    }
}
