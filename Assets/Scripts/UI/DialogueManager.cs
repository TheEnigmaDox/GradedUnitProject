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

    public string narcoticToSpawn;
    Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject alcohol;
    public GameObject heroine;
    public GameObject speed;

    public GameObject contButton;
    public GameObject yesButton;
    public GameObject noButton;

    AudioSource typeAudio;
    public Animator dialogueBoxAnimator;

    TommyController tommyController;

    // Start is called before the first frame update
    void Start()
    {
        tommyController = FindObjectOfType<TommyController>();

        typeAudio = GetComponent<AudioSource>();

        sentences = new Queue<string>();

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        typeAudio.Stop();
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

        Debug.Log(narcoticToSpawn);
    }

    public void SpawnNarcotic()
    {
        if(narcoticToSpawn == "Alcohol")
        {
            Instantiate(alcohol, new Vector2(-6, 12), Quaternion.identity);
        }
        else if (narcoticToSpawn == "Heroine")
        {
            Instantiate(heroine, new Vector2(-15, 1.5f), Quaternion.identity);
        }
        if (narcoticToSpawn == "Speed")
        {
            Instantiate(speed, new Vector2(-14.75f, 10), Quaternion.identity);
        }

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        EndDialogue();
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
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);

            Debug.Log("Question logic here");
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        contButton.SetActive(false);

        if (!typeAudio.isPlaying)
        {
            typeAudio.Play();
        }

        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            
            yield return new WaitForSeconds(typeSpeed);
        }

        if (dialogueText.text == sentence)
        {
            typeAudio.Stop();
            contButton.SetActive(true);
        }
    }

    public void EndDialogue()
    {
        dialogueOpen = false;
        contButton.SetActive(false);
    }
}
