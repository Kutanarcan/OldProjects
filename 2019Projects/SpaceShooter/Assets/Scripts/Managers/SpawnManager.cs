using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct SpawnObjectList
{
    public SpawnType spawnType;
    public List<GameObject> spawnList;
}
public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoint;
    [SerializeField]
    private SpawnObjectList[] spawnStructs;
    [SerializeField]
    private float startTime;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float spawnRateRange;
    [SerializeField]
    private PowerUpDisplayData spawnerData;
    private float spawnTimer;
    private SpawnIndicator spawnIndicator;
    private Dictionary<SpawnType, List<GameObject>> spawnObjects;
    private void Awake()
    {
        spawnIndicator = GetComponent<SpawnIndicator>();
        spawnObjects = spawnIndicator.InitializeSpawnObjects();
        SetSpawnObjectLists();
    }
    private void OnEnable()
    {
        startTime = spawnerData.leftOverTime;
    }
    private void SetSpawnObjectLists()
    {
        foreach (SpawnObjectList spwnStruct in spawnStructs)
        {
            spawnObjects[spwnStruct.spawnType] = spwnStruct.spawnList;
        }
    }
    private void Update()
    {
        SpawnObjects();
    }
    private void SpawnObjects()
    {
        if (spawnTimer <= 0)
        {
            CalculateTimer();
            Spawn();
        }
        else
        {
            DecereaseTimer();
        }

        void CalculateTimer()
        {
            if (startTime > spawnRateRange)
            {
                startTime -= spawnRate;
            }
            spawnTimer = startTime;
        }

        void DecereaseTimer()
        {
            spawnTimer -= Time.deltaTime;
        }
    }
    private void Spawn()
    {
        //TODO: Write Better Logic Spawner
        int randSpawn = Random.Range(1, 4);

        for (int i = 0; i < randSpawn; i++)
        {
            int pickTypeOfObject = Chooser();
            int pickSpawnObject = Random.Range(0, spawnObjects[SpawnTypeIndexConverter(pickTypeOfObject)].Count);
            int spawnPointRandom = Random.Range(1, spawnPoint.Length);
            Instantiate(spawnObjects[SpawnTypeIndexConverter(pickTypeOfObject)][pickSpawnObject], spawnPoint[spawnPointRandom].position, Quaternion.identity);
        }
    }

    private int Chooser()
    {
        int persn = Random.Range(0, 101);
        int returnValue = 0;
        if (persn >= 0 && persn < 40)
        {
            returnValue = (int)SpawnType.Enemy;
        }
        else if (persn >= 40 && persn < 80)
        {
            returnValue = (int)SpawnType.Obstacle;
        }
        else
        {
            returnValue = (int)SpawnType.Collectable;
        }
        return returnValue;
    }
    private SpawnType SpawnTypeIndexConverter(int index)
    {
        SpawnType tmp = (SpawnType)index;
        return tmp;
    }
}
