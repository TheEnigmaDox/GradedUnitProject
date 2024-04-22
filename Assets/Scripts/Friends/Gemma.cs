using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Gemma : MonoBehaviour
{
    bool playerInRange;
    
    public GameObject dialogueBox;

    public List<string> dialogues = new List<string>();

    public DialogueManager dialogueManager;

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetButtonDown("Jump"))
        {
            dialogueManager.dialogueList = new List<string>();
            dialogueManager.dialogueList = dialogues;
            dialogueBox.SetActive(true);
            dialogueManager.narcotic = "Alcohol";
            dialogueManager.ResetDialogue();
        }

        Debug.Log("Player in range : " + playerInRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
        dialogueManager.ResetDialogue();
        dialogueBox.SetActive(false);
    }
}
