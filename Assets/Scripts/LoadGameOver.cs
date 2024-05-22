using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOver : MonoBehaviour
{
    // Reference to the Stats script
    Stats stats;

    // Start is called before the first frame update
    private void Start()
    {
        // Find and store a reference to the Stats script in the scene
        stats = FindObjectOfType<Stats>();
    }

    // Called when the attached GameObject's collider enters another collider trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider's tag is "Player"
        if (collision.CompareTag("Player"))
        {
            // Set the survive variable in the Stats script to true
            stats.survive = true;

            // Load the game over scene (scene index 4)
            SceneManager.LoadScene(4);
        }
    }
}
