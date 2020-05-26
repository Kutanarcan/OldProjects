﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy State", menuName = "ScriptableObjects/Enemy/PatrolState")]
public class PatrolState : State
{
    [HideInInspector]
    public List<Vector3> blockedDirections;

    private Transform enemyTransform;
    private LayerMask obstacle;
    private List<Vector3> hitTransforms;
    private List<Vector3> directions;
    private EnemyMovement enemyMovement;

    public PatrolState(Transform transform, LayerMask mask)
    {
        enemyTransform = transform;
        obstacle = mask;
        enemyMovement = transform.GetComponent<EnemyMovement>();

        hitTransforms = new List<Vector3>();
        directions = new List<Vector3>();
        blockedDirections = new List<Vector3>();

        hitTransforms.Add(enemyTransform.up);//UP
        hitTransforms.Add(-enemyTransform.up);//DOWN
        hitTransforms.Add(enemyTransform.right);//RIGHT
        hitTransforms.Add(-enemyTransform.right);//LEFT
    }
    public override void EnterState()
    {
        FillDirectionList();
        if (directions.Count > 0)
        {
            int rand = Random.Range(0, directions.Count);
            enemyMovement.SetDirection(directions[rand]);
            directions.Clear();
        }
        else
        {
            enemyMovement.SetDirection(enemyTransform.up);
        }
    }
    public override void ExitState()
    {

    }
    private void FillDirectionList()
    {
        for (int i = 0; i < hitTransforms.Count; i++)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(enemyTransform.position, hitTransforms[i], 1f, obstacle);
            Debug.DrawRay(enemyTransform.position, hitTransforms[i], Color.red, 1f);

            if (hitInfo.collider == null)
                directions.Add(hitTransforms[i]);
        }
    }
}
