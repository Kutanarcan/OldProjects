using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStatDisplayer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI lifetext;
    [SerializeField]
    private TextMeshProUGUI bulletCountText;
    [SerializeField]
    private GameObject gameplayPanel;
    [SerializeField]
    private BasePlayer player;
    private void OnDisable()
    {
        player = null;
    }
    private void Update()
    {
        //TODO: Not Optimized. We need to call this function when we make change.(Event)
        UpdatePlayerStat();
    }
    private void UpdatePlayerStat()
    {
        //TODO: Not Optimized Find a way to remove the if-else statement.
        if (player == null)
        {
            player = BasePlayer.Instance;
        }
        else
        {
            scoreText.text = $"SCORE:" + player.Score.ToString();
            lifetext.text = $"LIFE:" + player.playerHealth.ToString();
            bulletCountText.text = "I";
        }
    }
}
