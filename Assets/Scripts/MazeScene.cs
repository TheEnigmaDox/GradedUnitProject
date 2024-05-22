using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MazeScene : MonoBehaviour
{
    // Variables to store toxic amount and maze timer
    float toxAmount = 0;
    float mazeTimer = 0;

    // Different timer values for easy, medium, and hard modes
    float easyTimer = 120;
    float mediumTimer = 60;
    float hardTimer = 30;

    // Reference to the timer text UI element
    public TMP_Text timerText;

    // Reference to the main camera
    public Camera mainCam;

    // Reference to the Stats script
    Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the Stats script in the scene
        stats = FindObjectOfType<Stats>();

        // Retrieve toxic amount from Stats script if available
        if (stats != null)
        {
            toxAmount = stats.toxLevel;
        }

        // Set camera size and maze timer based on toxic amount
        if (toxAmount < 25)
        {
            mainCam.orthographicSize = 7; // Set camera size for easy mode
            mazeTimer = easyTimer; // Set maze timer for easy mode
        }
        else if (toxAmount > 25 && toxAmount < 75)
        {
            mainCam.orthographicSize = 5; // Set camera size for medium mode
            mazeTimer = mediumTimer; // Set maze timer for medium mode
        }
        else if (toxAmount > 75)
        {
            mainCam.orthographicSize = 2; // Set camera size for hard mode
            mazeTimer = hardTimer; // Set maze timer for hard mode
        }

        // Log maze timer value for debugging
        Debug.Log("Maze Timer : " + mazeTimer);
    }

    // Update is called once per frame
    void Update()
    {
        // Update maze timer countdown
        if (mazeTimer > 0)
        {
            mazeTimer -= Time.deltaTime;
            UpdateTimer(mazeTimer); // Update UI timer display
        }
        else if (mazeTimer <= 0)
        {
            stats.survive = false; // Set survive status to false
            SceneManager.LoadScene(4); // Load game over scene
        }
    }

    // Update UI timer display with minutes and seconds
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}