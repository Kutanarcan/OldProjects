using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float bottomEdge;
    [SerializeField]
    private float moveSpeed;
    void Update()
    {
        if (transform.position.y > bottomEdge)
        {
            ReplaceTheBackground();
        }
        else
        {
            MoveTheBackground();
        }
    }
    private void MoveTheBackground()
    {
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }
    private void ReplaceTheBackground()
    {
        transform.position = new Vector3(0, (transform.position.y - 14.3f * 3f), 0);
    }
}
