using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroin : MonoBehaviour
{
    float intoxicationAmount;

    UIScript uiScript;
    TommyController tommyController;

    // Start is called before the first frame update
    void Start()
    {
        tommyController = FindObjectOfType<TommyController>();
        uiScript = FindObjectOfType<UIScript>();

        intoxicationAmount = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            uiScript.AddIntoxication(intoxicationAmount);  
            tommyController.onHeroin = true;
            tommyController.heroinTimer = 5f;
            Destroy(gameObject);
        }
    }
}
