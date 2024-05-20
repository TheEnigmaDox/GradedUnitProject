using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    float intoxicationAmount;

    UIScript uiScript;
    TommyController tommyController;
    AudioSource speedAudio;

    // Start is called before the first frame update
    void Start()
    {
        tommyController = FindObjectOfType<TommyController>();
        uiScript = FindObjectOfType<UIScript>();

        speedAudio = GetComponent<AudioSource>();   

        intoxicationAmount = 50f;

        speedAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            speedAudio.Play();
            uiScript.AddIntoxication(intoxicationAmount);
            tommyController.onSpeed = true;
            tommyController.speedTimer += 5f;
            tommyController.moveSpeed += 100f;
            StartCoroutine(DestroySpeed());
        }
    }

    IEnumerator DestroySpeed()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
