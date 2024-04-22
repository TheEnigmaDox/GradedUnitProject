using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    float waitTime = 1f;

    public Animator transitionAnim;

    // Update is called once per frame
    void Update()
    {
            
    }

    public void LoadNextScene(int sceneIndex)
    {
        StartCoroutine(LoadLevel(sceneIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transitionAnim.SetTrigger("StartFade");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelIndex);
    }
}
