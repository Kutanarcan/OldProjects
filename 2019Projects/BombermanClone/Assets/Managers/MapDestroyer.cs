using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public static MapDestroyer Instance { get; private set; }

    [SerializeField]
    private Tilemap gameplayTilemap;
    [SerializeField]
    private Tile solidBlock;
    [SerializeField]
    private Tile explodeBlock;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject blockDestroyEffect;
    [SerializeField]
    private GameObject explosionSound;
    [SerializeField]
    private GameObject crackSound;

    private GameManager gameManager;

    int[] xAxis = { 1, 0, -1, 0 };
    int[] yAxis = { 0, 1, 0, -1 };

    const int NUMBER_OF_EXPLOSION_AXIS = 4;
    private void Awake()
    {
        //TODO: Can't use dynamic
        //Every scene has this class...
        //TODO: Find way to make this DontDestroyOnLoad
        //PROBLEM: Cannot send the right Gameplay Tilemap.
        if (Instance == null)
        {
            Instance = this;
        }
        CustomEventSystem.LevelChangedAction(gameplayTilemap);
    }

    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.IsGameStarted = true;
        gameManager.StartTime += Time.time;
    }

    public void Explode(Vector2 bombPosition, int range)
    {
        Vector3Int originCell = gameplayTilemap.WorldToCell(bombPosition);
        ExplodeCell(originCell);

        for (int n = 1; n < range; n++)
        {
            for (int k = 0; k < NUMBER_OF_EXPLOSION_AXIS; k++)
            {
                ExplodeCell(originCell + new Vector3Int(n * xAxis[k], n * yAxis[k], 0));
            }
        }
    }
    private bool ExplodeCell(Vector3Int cell)
    {
        Tile tile = gameplayTilemap.GetTile<Tile>(cell);

        if (tile == solidBlock)
        {
            return false;
        }

        if (tile == explodeBlock)
        {
            gameplayTilemap.SetTile(cell, null);
            ExplosionEffect(blockDestroyEffect);
            SoundManager.PlaySound(crackSound, 3f);

            return false;
        }

        GameObject tmpExp = Instantiate(explosionSound);
        Destroy(tmpExp, 2f);
        ExplosionEffect(explosionPrefab);

        return true;

        void ExplosionEffect(GameObject prefab)
        {
            Vector3 pos = gameplayTilemap.GetCellCenterWorld(cell);
            GameObject tmp = Instantiate(prefab, pos, Quaternion.identity);
            Destroy(tmp, 0.75f);
        }
    }
}
