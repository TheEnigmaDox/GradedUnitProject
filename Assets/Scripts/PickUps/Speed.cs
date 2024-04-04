using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    float intoxicationAmount;

    UIScript uiScript;
    TommyController tommyController;

    // Start is called before the first frame update
    void Start()
    {
        tommyController = FindObjectOfType<TommyController>();
        uiScript = FindObjectOfType<UIScript>();

        intoxicationAmount = 15f;
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
            tommyController.onSpeed = true;
            tommyController.speedTimer += 5f;
            tommyController.moveSpeed += 100f;
            Destroy(gameObject);
        }
    }
}
