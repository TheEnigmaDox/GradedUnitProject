using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    // Reference to the audio source component
    AudioSource impactSource;

    // List of audio clips to be played upon triggering the scene
    public List<AudioClip> audioClips;

    // Reference to the SceneLoader script
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the SceneLoader script in the scene
        sceneLoader = FindAnyObjectByType<SceneLoader>();

        // Get and store a reference to the AudioSource component attached to the GameObject
        impactSource = GetComponent<AudioSource>();

        // Stop the audio source from playing initially
        impactSource.Stop();
    }

    // Called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding GameObject has the "Player" tag
        if (collision.CompareTag("Player"))
        {
            // Set the "isSwimming" flag of the TommyController script attached to the player to true
            collision.GetComponent<TommyController>().isSwimming = true;

            // Load the next scene (index 3) using the SceneLoader script
            sceneLoader.LoadNextScene(3);
        }
    }
}