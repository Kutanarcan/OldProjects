﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerBomb playerBomb;
    private void Awake()
    {
        playerBomb = GetComponent<PlayerBomb>();
    }
    void Update()
    {
        HandleInput();
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBomb.SpawnBomb();
        }
    }
}
