using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource startBackgroundAudio;

    void Start()
    {
        startBackgroundAudio.Play();
    }
}
