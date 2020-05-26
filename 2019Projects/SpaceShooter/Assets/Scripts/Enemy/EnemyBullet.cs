using UnityEngine;
public class EnemyBullet : MonoBehaviour
{
    public Transform Target { get; set; }
    [SerializeField]
    private float bulletSpeed;
    private void Update()
    {
        // Debug.Log(Target);
        if (Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, bulletSpeed * Time.deltaTime);
            BulletReactThePosition();
        }
    }
    public void BulletReactThePosition()
    {
        if (transform.position.x == Target.position.x && transform.position.y == Target.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
