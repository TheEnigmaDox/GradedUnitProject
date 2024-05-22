using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static reference to the GameManager instance
    public static GameManager Instance;

    // Reference to the TommyController script
    TommyController tommyController;

    // Start is called before the first frame update
    void Start()
    {
        // If an instance of GameManager already exists and it's not this instance, destroy this instance
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Set this instance as the GameManager instance
            Instance = this;
        }

        // Prevents this GameObject from being destroyed when loading a new scene
        DontDestroyOnLoad(this.gameObject);

        // Find and store a reference to the TommyController script in the scene
        tommyController = FindObjectOfType<TommyController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the target frame rate to 60 frames per second
        Application.targetFrameRate = 60;
    }
}
