using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    // References to UI elements
    public Image titleBackground;
    public Button startButton, instructionsButton, exitButton;
    public GameObject instructionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be placed here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic can be added here if needed
    }

    // Load the next scene when the start button is clicked
    public void LoadNextScene()
    {
        SceneManager.LoadScene(1); // Load the scene with build index 1
    }
}