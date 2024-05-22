using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // ToxLevel represents the intoxication level of the player
    public float toxLevel = 0f;

    // Boolean flag indicating whether the player survived
    public bool survive;

    // Reference to the UIScript for updating the intoxication level
    UIScript uiScript;

    // Static instance of Stats to ensure only one instance exists throughout the game
    public static Stats statsInstance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Check if another Stats instance exists
        if (statsInstance != null && statsInstance != this)
        {
            // If another instance exists, destroy this instance
            Destroy(statsInstance);
        }
        else
        {
            // If no other instance exists, set this as the instance
            statsInstance = this;
        }

        // Make sure this object persists when loading new scenes
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the UIScript in the scene
        uiScript = FindObjectOfType<UIScript>();

        // Output the initial toxLevel to the console for debugging purposes
        Debug.Log(toxLevel);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the toxLevel with the current value of the intoxication slider from the UIScript
        toxLevel = uiScript.intoxicationSlider.value;

        // Output the value of the survive flag to the console for debugging purposes
        Debug.Log("Survive : " + survive);
    }
}