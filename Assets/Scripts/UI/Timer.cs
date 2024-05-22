using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements like Image
using TMPro; // Required for TextMeshPro text components
using UnityEngine.SceneManagement; // Required for scene management

public class Timer : MonoBehaviour
{
    // Serialized field for the time left and the maximum time allowed
    [SerializeField] float timeLeft;
    [SerializeField] float maxTimer;

    // Reference to the text component displaying the timer
    [SerializeField] TMP_Text timerText;

    // Reference to the timer's background image
    public Image timerBackground;

    // Reference to the SceneLoader script
    public SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        // Finding and storing a reference to the SceneLoader script in the scene
        sceneLoader = FindObjectOfType<SceneLoader>();

        // Initializing the time left to the maximum timer value
        timeLeft = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        // If there is still time left
        if (timeLeft > 0)
        {
            // Decrease the time left based on real-time
            timeLeft -= Time.deltaTime;

            // Update the timer display
            UpdateTimer(timeLeft);
        }
        else
        {
            // If time is up, log a message, reset the time left to 0, and load the next scene
            Debug.Log("Time is up!");
            timeLeft = 0;
            sceneLoader.LoadNextScene((SceneManager.GetActiveScene().buildIndex + 1));
        }

        // If the current scene is the second scene
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            // Hide the timer background and clear the timer text
            timerBackground.GetComponent<Image>().enabled = false;
            timerText.text = "";
        }
    }

    // Method to update the timer display
    void UpdateTimer(float currentTime)
    {
        // Increment currentTime by 1 to prevent displaying 0 seconds when the timer runs out
        currentTime += 1;

        // Calculate minutes and seconds from currentTime
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the timer text to display minutes and seconds
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}