using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alcohol : MonoBehaviour
{
    float intoxicationAmount;

    UIScript uiScript;

    TommyController tommyController;

    AudioSource drinkAudio;

    // Start is called before the first frame update
    void Start()
    {
        tommyController = FindObjectOfType<TommyController>();
        drinkAudio = GetComponent<AudioSource>();   
        uiScript = FindObjectOfType<UIScript>();

        intoxicationAmount = 15f;

        drinkAudio.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            drinkAudio.Play();
            uiScript.AddIntoxication(intoxicationAmount);
            tommyController.isDrunk = true;
            tommyController.alcoholTimer += 5f;
            StartCoroutine(DestroyAlcohol());
            
        }
    }

    IEnumerator DestroyAlcohol()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
