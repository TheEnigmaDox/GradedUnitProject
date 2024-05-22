using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    // Amount of intoxication the player receives when interacting with this object
    float intoxicationAmount;

    // Reference to the UI script to update the intoxication level
    UIScript uiScript;
    // Reference to the player controller script
    TommyController tommyController;
    // Audio source component to play the speed use sound
    AudioSource speedAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Find and assign the player controller script in the scene
        tommyController = FindObjectOfType<TommyController>();
        // Find and assign the UI script in the scene
        uiScript = FindObjectOfType<UIScript>();

        // Get the AudioSource component attached to this object
        speedAudio = GetComponent<AudioSource>();

        // Set the intoxication amount that this object provides
        intoxicationAmount = 50f;

        // Ensure the speed use sound is not playing at the start
        speedAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method called when another collider enters this object's trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider belongs to the player
        if (collision.CompareTag("Player"))
        {
            // Play the speed use sound
            speedAudio.Play();
            // Update the UI to add the intoxication amount
            uiScript.AddIntoxication(intoxicationAmount);
            // Set the player's speed status to true
            tommyController.onSpeed = true;
            // Increase the player's speed timer
            tommyController.speedTimer += 5f;
            // Increase the player's move speed
            tommyController.moveSpeed += 100f;
            // Start the coroutine to destroy this speed object after a delay
            StartCoroutine(DestroySpeed());
        }
    }

    // Coroutine to destroy the speed object after a short delay
    IEnumerator DestroySpeed()
    {
        // Wait for 0.3 seconds
        yield return new WaitForSeconds(0.3f);
        // Destroy this game object
        Destroy(gameObject);
    }
}
