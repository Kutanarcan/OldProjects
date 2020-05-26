using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float BulletSpeed { get { return bulletSpeed; } set { bulletSpeed = value; } }
    private float bulletSpeed;
    [SerializeField]
    private PlayerBulletData bulletData;
    private void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * bulletData.changeableBulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable component = (IDamagable)other.GetComponent(typeof(IDamagable));

        if (component != null && !other.CompareTag(TagContainer.Player_Tag))
        {
            component.ApplyDamage(1);
            Destroy(gameObject);
        }
        else if (other.CompareTag(TagContainer.Top_Border))
        {
            Destroy(gameObject);
        }
    }
}
