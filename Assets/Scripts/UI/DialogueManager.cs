using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    bool dialogueOpen = false;

    float typeSpeed = 0.05f;

    string question = "Would you like some booze to get you in the vibe!";
    Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject contButton;
    
    public Animator dialogueBoxAnimator;

    TommyController tommyController;

    // Start is called before the first frame update
    void Start()
    {
        tommyController = FindObjectOfType<TommyController>();

        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        dialogueBoxAnimator.SetBool("isOpen", dialogueOpen);

        if(dialogueOpen)
        {
            tommyController.playerControl = false;
        }
        else
        {
            tommyController.playerControl = true;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueOpen = true;

        nameText.text = dialogue.speakerName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else if(sentences.Count == 1)
        {
            Debug.Log("Question logic here");
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        contButton.SetActive(false);

        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        if (dialogueText.text == sentence)
        {
            contButton.SetActive(true);
        }

    }

    void EndDialogue()
    {
        dialogueOpen = false;
        contButton.SetActive(false);
    }
}
