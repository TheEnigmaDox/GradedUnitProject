using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Signs : MonoBehaviour
{
    // Boolean flag to track whether the player is in range of the sign
    bool playerInRange = false;

    // Typing speed for displaying the sign text
    float typeSpeed = 0.05f;

    // Empty string used for resetting the text
    string emptyString = "";

    // The text to be displayed on the sign
    public string signText;

    // Reference to the TextMeshPro text component
    public TMP_Text text;

    // Reference to the game object representing the sign's text box
    public GameObject textBox;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialization code can be placed here if needed
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the player is in range and the jump button is pressed
        if (playerInRange && Input.GetButtonDown("Jump"))
        {
            // Activate the text box and start typing the text
            textBox.SetActive(true);
            text.text = emptyString; // Clear the text
            StartCoroutine(TypeText()); // Start typing the text
        }
    }

    // Called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding GameObject has the "Player" tag
        if (collision.CompareTag("Player"))
        {
            // Set playerInRange flag to true and clear the text
            playerInRange = true;
            text.text = emptyString;
        }
    }

    // Called when another collider exits the trigger collider attached to this GameObject
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Clear the text, deactivate the text box, and set playerInRange flag to false
        text.text = emptyString;
        textBox.SetActive(false);
        playerInRange = false;
    }

    // Coroutine to type out the sign text letter by letter
    IEnumerator TypeText()
    {
        text.text = emptyString; // Clear the text

        // Loop through each character in the sign text
        foreach (char letter in signText)
        {
            text.text += letter; // Append the current letter to the text
            yield return new WaitForSeconds(typeSpeed); // Wait for a short duration
        }
    }
}
