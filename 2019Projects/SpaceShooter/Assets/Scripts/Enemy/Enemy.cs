using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable, IGiveScore
{
    public Transform Target { get; set; }
    [SerializeField]
    private GameObject destroyEffect;
    [SerializeField]
    private ParticalManager particalManager;
    [SerializeField]
    private GameObject destroySound;
    public void ApplyDamage(float amount)
    {
        this.Target = null;
        Destroy(this.gameObject);
        ApplyScore(1);
    }
    private void OnDisable()
    {
        particalManager.Effect(destroyEffect, 1f, this.transform);
        AudioManager.SetupAudio(destroySound, 1f);
    }
    public void ApplyScore(int amount)
    {
        CustomEventSystem.ScoreCountAction(amount);
    }
}
