using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PowerUpTrigger : MonoBehaviour
{
    [SerializeField]
    private PowerUp powerUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagContainer.Player_Tag))
        {
            if (powerUp is Shootable)
            {
                BulletActivator.SetBullet((Shootable)powerUp);
            }
            CustomEventSystem.PickedUpPowerUpAction(powerUp);
            Destroy(this.gameObject);
        }
    }
}
