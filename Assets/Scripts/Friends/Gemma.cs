using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Gemma : MonoBehaviour
{
    int dialogueIndex = 0;

    bool playerInRange = false;

    public TMP_Text dialogueText;
    public GameObject dialogueBox;

    public List<string> dialogue = new List<string>();
    public List<string> dialogueOptions = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        dialogueOptions = dialogue;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetButtonDown("Jump"))
        {
            dialogueBox.SetActive(true);
            dialogueText.text = dialogueOptions[dialogueIndex];
        }

        if (dialogueIndex > dialogueOptions.Count)
        {
            
        }
    }

    public void AdvanceText()
    {
        if(dialogueIndex == dialogueOptions.Count - 1)
        {
            dialogueText.text = "";
            dialogue.Clear();
        }

        dialogueIndex++;

        if (dialogueOptions.Count > 0)
        {
            dialogueText.text = dialogueOptions[dialogueIndex]; 
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}
