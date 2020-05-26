using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour, IDamagable
{
    private static BasePlayer instance;
    public static BasePlayer Instance { get { return instance; } }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerShoot PlayerShoot { get; private set; }
    public int Score { get; private set; }
    public GameObject Shield { get => shield; }
    public bool IsShieldActive { get => isShieldActive; set => isShieldActive = value; }
    public ShootController shootController { get; private set; }
    [SerializeField]
    public float playerHealth;
    [SerializeField]
    private int bulletCount;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private Color hurtColor;
    [SerializeField]
    private float hurtTime;
    [SerializeField]
    private GameObject hurtSound;
    [SerializeField]
    private GameObject deadSound;
    private bool isShieldActive;
    private WaitForSeconds hurtDuration;
    private void Awake()
    {
        hurtDuration = new WaitForSeconds(hurtTime);
        IsShieldActive = false;
        if (instance == null)
            instance = this;
        CustomEventSystem.TakeDamage += ApplyDamage;
        CustomEventSystem.ScoreCount += ScoreAdder;
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerShoot = GetComponent<PlayerShoot>();
        shootController = GetComponent<ShootController>();
    }
    private void OnDestroy()
    {
        CustomEventSystem.TakeDamage -= ApplyDamage;
        CustomEventSystem.ScoreCount -= ScoreAdder;
        instance = null;
    }
    private void ScoreAdder(int scoreAmount)
    {
        //TODO: Move to GameManager 
        Score += scoreAmount;
    }
    private void Death()
    {
        Destroy(this.gameObject);
        AudioManager.SetupAudio(deadSound, 1f);
        StopCoroutine(Hurt());
        CustomEventSystem.EndGameAction();
    }
    public void ApplyDamage(float damageAmount)
    {
        if (!isShieldActive)
        {
            if (playerHealth > 0)
            {
                playerHealth -= damageAmount;
                StartCoroutine(Hurt());
            }
            if (playerHealth < 1)
                Death();
        }
    }
    IEnumerator Hurt()
    {
        AudioManager.SetupAudio(hurtSound, 1f);
        this.GetComponent<SpriteRenderer>().material.color = hurtColor;
        yield return hurtDuration;
        this.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
