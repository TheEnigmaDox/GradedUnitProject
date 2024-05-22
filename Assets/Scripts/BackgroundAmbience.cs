using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundAmbience : MonoBehaviour
{
    // Flag to track whether the ambience audio is currently playing
    bool isPlaying = false;

    // Reference to the AudioSource component attached to this GameObject
    AudioSource ambienceAudio;

    // Static reference to the BackgroundAmbience instance
    public static BackgroundAmbience ambienceInstance;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        ambienceAudio = GetComponent<AudioSource>();

        // Stop the ambience audio when the script starts
        ambienceAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // If the ambience audio is not currently playing
        if (!isPlaying)
        {
            // Set isPlaying to true to prevent multiple plays
            isPlaying = true;

            // Set the audio to loop and start playing it
            ambienceAudio.loop = true;
            ambienceAudio.Play();
        }
    }
}
