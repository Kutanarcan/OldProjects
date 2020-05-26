using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable, IGiveScore
{
    [SerializeField]
    private float health;
    [SerializeField]
    private int scoreAmount;
    [SerializeField]
    private float damageAmount;
    [SerializeField]
    private GameObject[] destroySound;
    [SerializeField]
    private ParticalManager particalManager;
    [SerializeField]
    private GameObject destroyEffect;
    public void ApplyDamage(float amount)
    {
        if (health > 0)
        {
            health -= amount;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            ApplyScore(scoreAmount);
        }
    }
    public void ApplyScore(int amount)
    {
        CustomEventSystem.ScoreCountAction(amount);
    }
    private void OnDisable()
    {
        AudioManager.SetupAudio(destroySound, 1f);
        particalManager.Effect(destroyEffect, 1f, this.transform);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagContainer.Player_Tag))
        {
            Destroy(GetComponentInParent<Obstacle>().gameObject);
            ((IDamagable)other.GetComponent(typeof(IDamagable))).ApplyDamage(damageAmount);
        }
    }
}
