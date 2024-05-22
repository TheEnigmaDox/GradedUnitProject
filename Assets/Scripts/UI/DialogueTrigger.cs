using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Flag to check if the player is in range for triggering dialogue
    bool playerInRange = false;

    // The dialogue to trigger when interacting with this object
    public Dialogue dialogue;

    // Update is called once per frame
    private void Update()
    {
        // If player is in range and presses the jump button, trigger the dialogue
        if (playerInRange && Input.GetButtonDown("Jump"))
        {
            TriggerDialogue();
        }

        // Debug log the playerInRange state
        Debug.Log(playerInRange);
    }

    // Method to trigger the dialogue
    public void TriggerDialogue()
    {
        // Start the dialogue using the DialogueManager
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    // Method called when another Collider2D enters this object's trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the other collider is tagged as "Player", set playerInRange to true and set the narcoticToSpawn in DialogueManager
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            FindObjectOfType<DialogueManager>().narcoticToSpawn = dialogue.narcotic;
        }
    }

    // Method called when another Collider2D exits this object's trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        // If the other collider exits the trigger and it was the player, set playerInRange to false
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}