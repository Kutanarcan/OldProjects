﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementData movementData;
    private Vector2 movement;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        MoveAnimationSettings();
    }
    private void MoveAnimationSettings()
    {
        movement = new Vector2(movementData.HorizontalAxis, movementData.VerticalAxis);
        animator.SetFloat("Horizontal", movementData.HorizontalAxis);
        animator.SetFloat("Vertical", movementData.VerticalAxis);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
