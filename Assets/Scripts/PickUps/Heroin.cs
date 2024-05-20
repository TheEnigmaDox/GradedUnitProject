using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroin : MonoBehaviour
{
    float intoxicationAmount;

    UIScript uiScript;
    TommyController tommyController;

    AudioSource heroinAudio;

    // Start is called before the first frame update
    void Start()
    {
        tommyController = FindObjectOfType<TommyController>();
        uiScript = FindObjectOfType<UIScript>();
        heroinAudio = GetComponent<AudioSource>();

        intoxicationAmount = 75f;

        heroinAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            heroinAudio.Play();
            uiScript.AddIntoxication(intoxicationAmount);  
            tommyController.onHeroin = true;
            tommyController.heroinTimer = 5f;

            StartCoroutine(DestroyHerion());
        }
    }

    IEnumerator DestroyHerion()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
