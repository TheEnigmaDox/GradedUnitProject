using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Aiesha : MonoBehaviour
{
    int dialogueIndex = 0;

    bool playerInRange;
    bool dialogueOpen = false;

    public GameObject alcohol;
    public GameObject dialogueBox;

    public TMP_Text textToShow;

    public List<string> dialogues = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetButtonDown("Jump"))
        {
            dialogueOpen = true;
        }
        else if (!playerInRange)
        {
            dialogueOpen = false;
        }

        if (dialogueOpen)
        {
            dialogueBox.SetActive(true);
            textToShow.text = dialogues[dialogueIndex];
        }

        if(dialogueIndex < dialogues.Count - 1 && Input.GetMouseButtonDown(0))
        {
            dialogueIndex++;
        }

        if(dialogueIndex == dialogues.Count - 1 && Input.GetMouseButtonDown(0))
        {
            Instantiate(alcohol, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            dialogueIndex = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }
}
