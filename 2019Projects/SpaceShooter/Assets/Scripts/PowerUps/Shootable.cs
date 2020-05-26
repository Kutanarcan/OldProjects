using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chargeable Power Up", menuName = "ScriptableObjects/PowerUp/Shootable")]
public class Shootable : PowerUp
{
    public int bulletCount;
    public int index;
    public ShootType type;
    public Vector2[] points;
    public Vector2 originPoint;
    public PlayerBullet playerBulletPrefab;
    public PlayerBullet OriginBulletPrefab;
}
public enum ShootType
{
    Two,
    Three,
    Four
}