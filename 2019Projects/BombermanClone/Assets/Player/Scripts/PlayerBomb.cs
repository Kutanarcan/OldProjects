﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField]
    private BombData bombData;

    private GameManager gameManager;
    private Tilemap tilemap;

    private void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager != null)
            tilemap = gameManager.GetGameplayTilemap();
    }

    public void SpawnBomb()
    {
        if (bombData.bombCount > 0)
        {
            //Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 spawnPos = transform.position;
            Vector3Int cell = tilemap.WorldToCell(spawnPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
    }
}