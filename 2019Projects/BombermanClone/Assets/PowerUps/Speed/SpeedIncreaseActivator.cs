using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreaseActivator : BaseActivator
{
    [SerializeField]
    private PlayerMovementData playerMovement;
    public override void DoEffet()
    {
        playerMovement.MovementSpeed += 3;
    }
}
