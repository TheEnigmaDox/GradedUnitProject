using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Signs : MonoBehaviour
{
    bool playerInRange = false;

    float typeSpeed = 0.05f;

    string emptyString = "";
    public string signText;

    public TMP_Text text;

    public GameObject textBox;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(playerInRange && Input.GetButtonDown("Jump"))
        {
            textBox.SetActive(true);
            text.text = emptyString;
            StartCoroutine(TypeText());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRange = true;
            text.text = emptyString;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.text = emptyString;
        textBox.SetActive(false);
        playerInRange = false;
    }

    IEnumerator TypeText()
    {
        text.text = emptyString;

        foreach(char letter in signText)
        {
            text.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
