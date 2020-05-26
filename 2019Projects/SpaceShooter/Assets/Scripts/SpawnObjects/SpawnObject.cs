using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnObject
{
    public abstract SpawnType spawnType { get; }

    public List<GameObject> spawnList { get; protected set; }

    public void FillTheList(List<GameObject> listOfObj)
    {
        this.spawnList = new List<GameObject>();
        this.spawnList = listOfObj;
    }

    public void Spawn()
    {

    }

}
