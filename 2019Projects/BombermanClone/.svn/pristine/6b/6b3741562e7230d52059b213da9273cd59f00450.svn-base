using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable component = other.GetComponent<IDamagable>();

        if (component != null)
        {
            Destroy(other.gameObject);
            component.ApplyDamage();
        }

        if (other.CompareTag(TagContainer.BOMB_TAG))
        {
            Bomb tmp = other.gameObject.GetComponent<Bomb>();
            tmp.ApplyDamage();
        }

        if (other.CompareTag(TagContainer.PORTAL_TAG))
        {
            CustomEventSystem.PortalExplosionAction(transform.position);
        }
    }
}
