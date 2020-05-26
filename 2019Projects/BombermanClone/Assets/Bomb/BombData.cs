using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Data/Bomb")]
public class BombData : ScriptableObject
{
    public float countDown;
    public int range;
    public int bombCount;
}
