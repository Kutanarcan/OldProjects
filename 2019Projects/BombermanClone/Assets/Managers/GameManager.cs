using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject Player => playerPrefab;
    public float StartTime { get => startTime; set => startTime = value; }
    public int TimerIndex { get; set; }
    public bool IsGameStarted { get; set; }
    public float Score { get => score; set => score = value; }
    public int EnemyCount { get => enemyCount; set => enemyCount = value; }
    public int ComboCounter { get => comboCounter; set => comboCounter = value; }

    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private float deadTime;

    [Header("Data")]
    [SerializeField]
    private InitialGameData InitialGameData;
    [SerializeField]
    private BombData bombData;
    [SerializeField]
    private PlayerMovementData playerMovementData;
    [SerializeField]
    private PlayerOrigin playerOrigin;
    [SerializeField]
    private SceneData sceneData;
    [SerializeField]
    private GameObject enemyPrefab;

    private Tilemap gameplayTilemap;
    private float countTimer;
    private float score;
    private float startTime;
    private int enemyCount;
    private int comboCounter;
    private WaitForSeconds deadDuration;
    private WaitForSeconds createEnemyDuration;

    private void Awake()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "Level1" || activeScene == "MainMenu")
            SetInitialGameData();
        InitializeSingleton();
        CustomEventSystem.OnLevelChanged += SetGameplayElements;
        CustomEventSystem.OnPlayerDead += PlayerDead;
        CustomEventSystem.OnGameEnd += GameEnd;
        CustomEventSystem.OnPortalExplosion += PortalExplode;
        deadDuration = new WaitForSeconds(deadTime);

        createEnemyDuration = new WaitForSeconds(0.75f);
    }

    private void PortalExplode(Vector3 portalPos)
    {
        StartCoroutine(CreateEnemyCoroutine());

        IEnumerator CreateEnemyCoroutine()
        {
            yield return createEnemyDuration;
            Instantiate(enemyPrefab, portalPos, Quaternion.identity);
            EnemyCount++;
        }
    }
    private void GameEnd()
    {
        CustomEventSystem.UpdateGameInfoAction();
    }
    public void DecreaseEnemyCount()
    {
        EnemyCount--;
        if (EnemyCount < 1)
        {
            CustomEventSystem.WhenAllEnemiesDiedAction();
        }
    }
    private void InitializeSingleton()
    {
        //TODO: We can use Generic class.
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
    private void SetGameplayElements(Tilemap tilemap)
    {
        gameplayTilemap = tilemap;
        Instantiate(Player, playerOrigin.OriginPoint, Quaternion.identity);
        startTime = sceneData.levelInformations[TimerIndex].levelTime;
        enemyCount = sceneData.levelInformations[TimerIndex].enemyCount;
    }
    private void PlayerDead()
    {
        if (playerOrigin.PlayerLife > 0)
        {
            StartCoroutine(ReactToDeadCoroutine());
            IEnumerator ReactToDeadCoroutine()
            {
                playerOrigin.PlayerLife--;
                yield return deadDuration;
                CustomEventSystem.UpdateGameInfoAction();
                CustomEventSystem.LevelChangedAction(gameplayTilemap);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    public void SetInitialGameData()
    {
        //Initializing Game data when we start playing.
        bombData.bombCount = InitialGameData.startingBombCount;
        bombData.range = InitialGameData.startingBombRange;
        playerMovementData.MovementSpeed = InitialGameData.startingSpeed;
        playerOrigin.PlayerLife = InitialGameData.startingLife;
        score = InitialGameData.startingScore;
        startTime = InitialGameData.startingTime;
        ComboCounter = 0;
    }
    public Tilemap GetGameplayTilemap()
    {
        return gameplayTilemap;
    }
    private void Update()
    {
        CountTime();
    }
    public float CountTime()
    {
        if (IsGameStarted && countTimer >= 0)
        {
            countTimer = startTime - Time.time;
            UIManager.Instance.UpdateGameTime(countTimer);
        }
        return countTimer;
    }
    private void OnDestroy()
    {
        CustomEventSystem.OnLevelChanged -= SetGameplayElements;
        CustomEventSystem.OnPlayerDead -= PlayerDead;
        CustomEventSystem.OnGameEnd -= GameEnd;
        playerOrigin.PlayerLife = InitialGameData.startingLife;
        CustomEventSystem.UpdateGameInfoAction();
    }
    public static void LoadTheScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
