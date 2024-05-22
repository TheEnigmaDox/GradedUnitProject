using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Time to wait before loading the next scene after triggering the transition animation
    float waitTime = 1.5f;

    // Reference to the transition animation controller
    public Animator transitionAnim;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Any initialization code can be added here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // This method is currently not used, but can be used for any update-related logic
    }

    // Method to load the next scene with a transition animation
    public void LoadNextScene(int sceneIndex)
    {
        StartCoroutine(LoadLevel(sceneIndex)); // Start coroutine to load level with transition
    }

    // Coroutine to load level with transition animation
    IEnumerator LoadLevel(int levelIndex)
    {
        transitionAnim.SetTrigger("StartFade"); // Trigger the transition animation
        yield return new WaitForSeconds(waitTime); // Wait for the specified time
        SceneManager.LoadScene(levelIndex); // Load the specified scene
    }
}
