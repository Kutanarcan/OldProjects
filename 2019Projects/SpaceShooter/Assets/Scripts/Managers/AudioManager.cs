using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static void SetupAudio(GameObject audio, float lifeTime)
    {
        GameObject tmp = Instantiate(audio);
        DestroyAudio(tmp, lifeTime);
    }
    public static void SetupAudio(GameObject[] audio, float lifeTime)
    {
        int rand = Random.Range(0, audio.Length);
        GameObject tmp = Instantiate(audio[rand]);
        DestroyAudio(tmp, lifeTime);
    }
    private static void DestroyAudio(GameObject audio, float lifeTime) => Destroy(audio, lifeTime);
}
