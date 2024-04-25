using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public int dialogueIndex = 0;

    float typeSpeed = 0.05f;

    public Button continueButton;
    public Button yesButton;
    public Button noButton;

    public TMP_Text dialogueText;

    public string narcotic = "";
    string dialogueToShow = "";
    string question = "";
    public List<string> dialogueList = new List<string>();

    public GameObject speed;
    public GameObject alcohol;
    public GameObject heroine;
    public GameObject dialogueBox;

    public Gemma gemma;
    public Billy billy;
    public Aiesha aiesha;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeDialogue());
        Debug.Log("started");
    }

    // Update is called once per frame
    void Update()
    {
        question = "Would you like some " + narcotic + " to get in the vibe?";

        dialogueText.text = dialogueToShow;

        if (dialogueToShow.Length == dialogueList[dialogueIndex].Length)
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
        }

        Debug.Log(typeSpeed);
    }

    public void AdvanceText()
    {
        Debug.Log("Advancing Text!");
        dialogueToShow = "";

        if (dialogueIndex < dialogueList.Count - 1)
        {
            dialogueIndex++;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            dialogueIndex = 0;
            PlayerChoice();
        }
    }

    public IEnumerator TypeDialogue()
    {
        dialogueToShow = "";

        foreach (char letter in dialogueList[dialogueIndex])
        {
            dialogueToShow += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public IEnumerator TypeQuestion()
    {
        dialogueToShow = "";

        foreach (char letter in question)
        {
            dialogueToShow += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void PlayerChoice()
    {
        StartCoroutine(TypeQuestion());
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
    }

    public void PlayerYes()
    {
        dialogueToShow = "";     
        dialogueIndex = 0;
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        dialogueBox.SetActive(false);

        if (narcotic == "Alcohol")
        {
            Instantiate(alcohol, new Vector2(gemma.transform.position.x, gemma.transform.position.y - 1.5f), Quaternion.identity);
        }
        else if(narcotic == "Speed")
        {
            Instantiate(speed, new Vector2(billy.transform.position.x, billy.transform.position.y - 1.5f), Quaternion.identity);
        }
        else if(narcotic == "Heroine")
        {
            Instantiate(heroine, new Vector2(aiesha.transform.position.x, aiesha.transform.position.y - 1.5f), Quaternion.identity);
        }
    }

    public void PlayerNo()
    {
        ResetDialogue();
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        dialogueBox.SetActive(false);
    }

    public void ResetDialogue()
    {
        dialogueToShow = "";
        dialogueIndex = 0;
        //dialogueToShow = dialogueList[dialogueIndex];
    }
}
