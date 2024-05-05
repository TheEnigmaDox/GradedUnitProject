using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    float typeSpeed = 0.05f;

    Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject contButton;
    
    public Animator dialogueBoxAnimator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBoxAnimator.SetBool("isOpen", true);

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
        dialogueBoxAnimator.SetBool("isOpen", false);
    }
}
