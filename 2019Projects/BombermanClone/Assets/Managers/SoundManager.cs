﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //TODO: (Maybe) We could change this class's name.
    public void PlaySound(GameObject sound)
    {
        GameObject tmp = Instantiate(sound);
        Destroy(tmp, 2f);
    }
    public static void PlaySound(GameObject sound, float timer)
    {
        GameObject tmp = Instantiate(sound);
        Destroy(tmp, timer);
    }
}
