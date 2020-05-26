using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
public class SpawnIndicator : MonoBehaviour
{
    private Dictionary<SpawnType, List<GameObject>> spawnObjects;
    public Dictionary<SpawnType, List<GameObject>> InitializeSpawnObjects()
    {
        var spawnObjectList = Assembly.GetAssembly(typeof(SpawnObject)).GetTypes()
        .Where(myList => myList.IsClass && !myList.IsAbstract && myList.IsSubclassOf(typeof(SpawnObject)));
        spawnObjects = new Dictionary<SpawnType, List<GameObject>>();
        foreach (var spawnObj in spawnObjectList)
        {
            SpawnObject tmpSpawnObj = Activator.CreateInstance(spawnObj) as SpawnObject;
            spawnObjects.Add(tmpSpawnObj.spawnType, tmpSpawnObj.spawnList);
        }
        return spawnObjects;
    }
}
