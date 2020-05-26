using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Game Data",menuName ="ScriptableObjects/GameData")]
public class InitialGameData : GameData
{
    public int startingBombRange;
    public int startingLife;
    public int startingBombCount;
    public int startingScore;
    public float startingTime;
    public float startingSpeed;
}
