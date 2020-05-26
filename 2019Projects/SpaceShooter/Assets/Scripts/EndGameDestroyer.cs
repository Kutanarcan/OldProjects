using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDestroyer : MonoBehaviour
{
    private void Awake()
    {
        CustomEventSystem.EndGame += Destroy;
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        CustomEventSystem.EndGame -= Destroy;
    }
}
