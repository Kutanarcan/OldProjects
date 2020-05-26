using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Header("Instantiate When Game Start")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private GameObject background;
    [SerializeField]
    private GameObject PowerupController;
    private BasePlayer basePlayer;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        CustomEventSystem.NewGame += GameStart;
        CustomEventSystem.EndGame += EndGame;
    }

    private void GameStart()
    {
        GameObject tmp = Instantiate(player);
        basePlayer = tmp.GetComponent<BasePlayer>();
        ActivateTheObject(spawner);
        ActivateTheObject(background);
        ActivateTheObject(PowerupController);
    }
    private void ActivateTheObject(GameObject objectToActivete)
    {
        objectToActivete.SetActive(true);
    }
    private void DeActivateTheObject(GameObject objectToDeActivete)
    {
        objectToDeActivete.SetActive(false);
    }
    private void EndGame()
    {
        DeActivateTheObject(spawner);
        DeActivateTheObject(background);
        DeActivateTheObject(PowerupController);
        SaveBaseScore();
    }
    private void SaveBaseScore()
    {
        if (basePlayer.Score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", basePlayer.Score);
            Debug.Log(PlayerPrefs.GetInt("BestScore", 0));
        }
    }
}
