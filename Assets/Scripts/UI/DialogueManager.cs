using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Flag to check if the dialogue box is open
    bool dialogueOpen = false;

    // Speed at which the dialogue text is typed out
    float typeSpeed = 0.05f;

    // Example question for dialogue
    string question = "Would you like some booze to get you in the vibe!";

    // The type of narcotic to spawn
    public string narcoticToSpawn;

    // Queue to manage sentences in the dialogue
    Queue<string> sentences;

    // References to UI text components
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    // References to narcotic GameObjects
    public GameObject alcohol;
    public GameObject heroine;
    public GameObject speed;

    // References to UI buttons
    public GameObject contButton;
    public GameObject yesButton;
    public GameObject noButton;

    // Audio source for typing sound
    AudioSource typeAudio;

    // Animator for dialogue box animations
    public Animator dialogueBoxAnimator;

    // Reference to the player controller
    TommyController tommyController;

    // Start is called before the first frame update
    void Start()
    {
        // Find and store reference to the TommyController in the scene
        tommyController = FindObjectOfType<TommyController>();

        // Get the AudioSource component attached to this GameObject
        typeAudio = GetComponent<AudioSource>();

        // Initialize the sentence queue
        sentences = new Queue<string>();

        // Hide the yes and no buttons at the start
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        // Stop any audio that might be playing initially
        typeAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the animator to show/hide the dialogue box
        dialogueBoxAnimator.SetBool("isOpen", dialogueOpen);

        // Disable player control when dialogue is open
        if (dialogueOpen)
        {
            tommyController.playerControl = false;
        }
        else
        {
            tommyController.playerControl = true;
        }

        // Debug log the type of narcotic to spawn
        Debug.Log(narcoticToSpawn);
    }

    // Method to spawn the narcotic based on the selected type
    public void SpawnNarcotic()
    {
        if (narcoticToSpawn == "Alcohol")
        {
            Instantiate(alcohol, new Vector2(-6, 12), Quaternion.identity);
        }
        else if (narcoticToSpawn == "Heroine")
        {
            Instantiate(heroine, new Vector2(-15, 1.5f), Quaternion.identity);
        }
        else if (narcoticToSpawn == "Speed")
        {
            Instantiate(speed, new Vector2(-14.75f, 10), Quaternion.identity);
        }

        // Hide the yes and no buttons
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        // End the dialogue
        EndDialogue();
    }

    // Method to start a dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        dialogueOpen = true;

        // Set the speaker's name in the UI
        nameText.text = dialogue.speakerName;

        // Clear any existing sentences in the queue
        sentences.Clear();

        // Enqueue each sentence in the dialogue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Display the next sentence in the dialogue
        DisplayNextSentence();
    }

    // Method to display the next sentence in the dialogue
    public void DisplayNextSentence()
    {
        // If no more sentences, end the dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        // Show yes/no buttons if the last sentence is reached
        else if (sentences.Count == 1)
        {
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);

            Debug.Log("Question logic here");
        }

        // Dequeue the next sentence and start typing it out
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Coroutine to type out a sentence character by character
    IEnumerator TypeSentence(string sentence)
    {
        // Hide the continue button while typing
        contButton.SetActive(false);

        // Play typing sound if not already playing
        if (!typeAudio.isPlaying)
        {
            typeAudio.Play();
        }

        // Clear the dialogue text
        dialogueText.text = "";

        // Type out each character in the sentence
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        // Stop typing sound and show the continue button when done
        if (dialogueText.text == sentence)
        {
            typeAudio.Stop();
            contButton.SetActive(true);
        }
    }

    // Method to end the dialogue
    public void EndDialogue()
    {
        dialogueOpen = false;
        contButton.SetActive(false);
    }
}