using UnityEngine;
using TMPro;
using System;

public class PlayerGameOverDisplayer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    private BasePlayer player;
    private void Awake()
    {
        CustomEventSystem.EndGame += EndGameDisplayer;
    }
    private void EndGameDisplayer()
    {
        player = BasePlayer.Instance;
        scoreText.text = $"Your Score:" + player.Score.ToString();
        bestScoreText.text = $"Best Score:" + PlayerPrefs.GetInt("BestScore", 0);
    }
}
