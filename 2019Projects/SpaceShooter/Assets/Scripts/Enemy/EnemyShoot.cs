using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private Transform shootPoint;
    private Enemy myEnemy;
    private float shootTimer;
    [SerializeField]
    private float shootStartTime;
    [SerializeField]
    private EnemyBullet enemyBullet;
    public Transform Target { get; private set; }
    private void Awake()
    {
        shootPoint = GetComponentInChildren<EnemyShotPoint>().transform;
        myEnemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (myEnemy.Target != null)
        {
            if (shootTimer <= 0)
            {
                // FireTheBullet().Target = myEnemy.Target.transform;
                shootTimer = shootStartTime;
            }
            else
            {
                shootTimer -= Time.deltaTime;
            }
        }
    }
    private EnemyBullet FireTheBullet()
    {
        EnemyBullet tmpBullet = Instantiate(enemyBullet, shootPoint.position, Quaternion.identity);
        return tmpBullet;
    }
}
