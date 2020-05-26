using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI mainMenuBestScoreText;
    private void Start()
    {
        SetBestScore();
        CustomEventSystem.EndGame += SetBestScore;
    }
    public void ExitTheGame()
    {
        Application.Quit();
    }
    public void SetBestScore()
    {
        mainMenuBestScoreText.text = $"Best Score:" + PlayerPrefs.GetInt("BestScore", 0);
    }
}
