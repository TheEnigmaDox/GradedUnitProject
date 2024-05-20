using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    AudioSource impactSource;

    public List<AudioClip> audioClips;

    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindAnyObjectByType<SceneLoader>();
        impactSource = GetComponent<AudioSource>();

        impactSource.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<TommyController>().isSwimming = true;
            sceneLoader.LoadNextScene(3);
        }
    }
}
