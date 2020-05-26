using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Container", menuName = "ScriptableObjects/DataContainer/BulletQueue")]
public class BulletQueue : ScriptableObject
{
    public Queue<Shootable> shootables = new Queue<Shootable>();
}
