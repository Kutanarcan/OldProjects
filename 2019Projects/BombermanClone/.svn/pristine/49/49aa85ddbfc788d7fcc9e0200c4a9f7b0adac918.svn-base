using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    private const string LAST_LEVEL = "Level3";

    [SerializeField]
    private SceneData sceneData;
    [SerializeField]
    private GameObject[] successSounds;
    private bool canChangeScene;
    private void Awake()
    {
        CustomEventSystem.OnWhenAllEnemiesDied += AllEnemiesDied;
    }
    private void OnDisable()
    {
        CustomEventSystem.OnWhenAllEnemiesDied -= AllEnemiesDied;
    }
    private void AllEnemiesDied()
    {
        canChangeScene = true;

        int rand = Random.Range(0, successSounds.Length);
        SoundManager.PlaySound(successSounds[rand], 1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagContainer.PLAYER_TAG))
        {
            if (canChangeScene)
            {
                if (SceneManager.GetActiveScene().name == LAST_LEVEL)
                {
                    Debug.Log("Game Ended");
                    CustomEventSystem.GameEndedAction();
                    GameManager.Instance.TimerIndex = 0;

                    return;
                }

                GameManager.Instance.TimerIndex++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //TODO: Change this buildIndex to scene name.
            }
        }
    }
}
