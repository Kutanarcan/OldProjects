using UnityEngine;
using UnityEngine.UI;

public class ScreenDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject gameplayPanel;
    [SerializeField]
    private GameObject endGamePanel;
    private void Awake()
    {
        CustomEventSystem.EndGame += EndGame;
    }
    public void NewGame()
    {
        ActivateScreen(gameplayPanel);
        DeActivateScreen(mainMenuPanel);
        CustomEventSystem.StartNewGameAction();
    }
    private void ActivateScreen(GameObject screenPanel)
    {
        screenPanel.SetActive(true);
    }
    private void DeActivateScreen(GameObject screenPanel)
    {
        screenPanel.SetActive(false);
    }
    public void EndGame()
    {
        ActivateScreen(endGamePanel);
        DeActivateScreen(gameplayPanel);
    }
    public void RestartGame()
    {
        DeActivateScreen(endGamePanel);
        NewGame();
    }
    public void ReturnMainMenu()
    {
        DeActivateScreen(endGamePanel);
        ActivateScreen(mainMenuPanel);
    }
}
