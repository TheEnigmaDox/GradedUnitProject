using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeLeft;
    [SerializeField] float maxTimer;

    [SerializeField] TMP_Text timerText;

    public Image timerBackground;

    public SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();  
        timeLeft = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimer(timeLeft);
        }
        else
        {
            Debug.Log("Time is up!");
            timeLeft = 0;
            sceneLoader.LoadNextScene((SceneManager.GetActiveScene().buildIndex + 1));
        }

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            timerBackground.GetComponent<Image>().enabled = false;
            timerText.text = "";
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
