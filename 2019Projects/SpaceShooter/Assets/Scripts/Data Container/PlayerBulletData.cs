using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Container", menuName = "ScriptableObjects/DataContainer/PlayerBullet")]
public class PlayerBulletData : DataContainer
{
    public float changeableBulletSpeed;
    public float initialBulletSpeed;
}
