using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroin : MonoBehaviour
{
    // Amount of intoxication the player receives when interacting with this object
    float intoxicationAmount;

    // Reference to the UI script to update the intoxication level
    UIScript uiScript;
    // Reference to the player controller script
    TommyController tommyController;
    // Audio source component to play the heroin use sound
    AudioSource heroinAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Find and assign the player controller script in the scene
        tommyController = FindObjectOfType<TommyController>();
        // Find and assign the UI script in the scene
        uiScript = FindObjectOfType<UIScript>();
        // Get the AudioSource component attached to this object
        heroinAudio = GetComponent<AudioSource>();

        // Set the intoxication amount that this object provides
        intoxicationAmount = 75f;

        // Ensure the heroin use sound is not playing at the start
        heroinAudio.Stop();
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
            // Play the heroin use sound
            heroinAudio.Play();
            // Update the UI to add the intoxication amount
            uiScript.AddIntoxication(intoxicationAmount);
            // Set the player's heroin status to true
            tommyController.onHeroin = true;
            // Set the player's heroin timer
            tommyController.heroinTimer = 5f;

            // Start the coroutine to destroy this heroin object after a delay
            StartCoroutine(DestroyHerion());
        }
    }

    IEnumerator DestroyHerion()
    {
        // Coroutine to destroy the heroin object after a short delay
        yield return new WaitForSeconds(0.3f);
        // Destroy this game object
        Destroy(gameObject);
    }
}
