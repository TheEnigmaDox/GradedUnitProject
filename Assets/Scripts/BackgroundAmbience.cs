using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundAmbience : MonoBehaviour
{
    bool isPlaying = false;

    AudioSource ambienceAudio;

    public static BackgroundAmbience ambienceInstance;

    // Start is called before the first frame update
    void Start()
    {
        ambienceAudio = GetComponent<AudioSource>();

        ambienceAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            ambienceAudio.loop = true;
            ambienceAudio.Play();
        }
    }
}
