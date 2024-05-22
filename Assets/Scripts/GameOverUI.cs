using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    // Reference to the TextMeshPro text component for displaying game over message
    public TMP_Text game_over_text;

    // Reference to the Stats script
    Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        // Find and store a reference to the Stats script in the scene
        stats = FindObjectOfType<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the game over text based on the value of the survive variable in the Stats script
        switch (stats.survive)
        {
            case true:
                game_over_text.text = "You Have Survived";
                break;
            case false:
                game_over_text.text = "You Have Drowned";
                break;
        }
    }

    // Method to load the title scene
    public void LoadTitle()
    {
        SceneManager.LoadScene(0);
    }

    // Method to exit the game
    public void Exit()
    {
        Application.Quit();
    }
}
