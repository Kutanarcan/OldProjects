using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable component = (IDamagable)other.GetComponent(typeof(IDamagable));
        if (component != null && !other.CompareTag(TagContainer.Player_Tag))
        {
            component.ApplyDamage(10);
        }
    }
}
