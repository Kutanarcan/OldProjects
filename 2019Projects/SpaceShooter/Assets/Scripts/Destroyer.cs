using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    private void Awake()
    {
        Destroy(this.gameObject, lifeTime);
    }
}
