using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiesha : MonoBehaviour
{
    bool playerInRange;

    public GameObject dialogueBox;

    public List<string> dialogues = new List<string>();

    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetButtonDown("Jump"))
        {
            dialogueManager.dialogueList = new List<string>();
            dialogueManager.dialogueList = dialogues;
            dialogueBox.SetActive(true);
            dialogueManager.narcotic = "Heroine";
            dialogueManager.ResetDialogue();
        }
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
