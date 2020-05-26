using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float ShootTimer { get => shootTimer; set => shootTimer = value; }
    public WaitForSeconds WaitTime { get => waitTime; set => waitTime = value; }
    public bool IsCanShoot { get; private set; } = true;
    public PlayerBullet BulletPrefab { get => bulletPrefab; set => bulletPrefab = value; }
    [SerializeField]
    private PlayerBullet bulletPrefab;
    [SerializeField]
    private float shootTimer;
    private ShootController shootController;
    private WaitForSeconds waitTime;
    [SerializeField]
    private GameObject[] laserShots;
    private void Awake()
    {
        waitTime = new WaitForSeconds(ShootTimer);
        shootController = GetComponent<ShootController>();
    }
    public void Shoot()
    {
        if (IsCanShoot)
        {
            AudioManager.SetupAudio(laserShots, 1f);
            StartCoroutine(PlayerShootTimer());
            foreach (Transform point in shootController.shotPoints)
            {
                if (point.gameObject.activeSelf)
                    Instantiate(BulletPrefab, point.transform.position, Quaternion.identity);
            }
        }
    }
    IEnumerator PlayerShootTimer()
    {
        IsCanShoot = false;
        yield return waitTime;
        IsCanShoot = true;
    }
    public void ChangeThePrefab(PlayerBullet powerUpBullet)
    {
        bulletPrefab = powerUpBullet;
    }
}
