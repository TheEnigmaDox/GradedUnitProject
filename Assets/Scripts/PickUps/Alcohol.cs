using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alcohol : MonoBehaviour
{
    // Amount of intoxication the player receives when interacting with this object
    float intoxicationAmount;

    // Reference to the UI script to update the intoxication level
    UIScript uiScript;

    // Reference to the player controller script
    TommyController tommyController;

    // Audio source component to play drinking sound
    AudioSource drinkAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Find and assign the player controller script in the scene
        tommyController = FindObjectOfType<TommyController>();

        // Get the AudioSource component attached to this object
        drinkAudio = GetComponent<AudioSource>();

        // Find and assign the UI script in the scene
        uiScript = FindObjectOfType<UIScript>();

        // Set the intoxication amount that this object provides
        intoxicationAmount = 15f;

        // Ensure the drinking sound is not playing at the start
        drinkAudio.Stop();

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
            // Play the drinking sound
            drinkAudio.Play();
            // Update the UI to add the intoxication amount
            uiScript.AddIntoxication(intoxicationAmount);
            // Set the player's drunk status to true
            tommyController.isDrunk = true;
            // Increase the player's alcohol timer
            tommyController.alcoholTimer += 5f;
            // Start the coroutine to destroy this alcohol object after a delay
            StartCoroutine(DestroyAlcohol());
            
        }
    }

    // Coroutine to destroy the alcohol object after a short delay
    IEnumerator DestroyAlcohol()
    {
        // Wait for 0.3 seconds
        yield return new WaitForSeconds(0.3f);
        // Destroy this game object
        Destroy(gameObject);
    }
}
