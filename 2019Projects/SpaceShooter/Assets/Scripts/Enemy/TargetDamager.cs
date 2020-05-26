using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagContainer.Player_Tag))
        {
            Destroy(GetComponentInParent<Enemy>().gameObject);
            other.GetComponent<IDamagable>().ApplyDamage(1);
            //((IDamagable)other.GetComponent(typeof(IDamagable))).ApplyDamage(1);
        }
    }
}
