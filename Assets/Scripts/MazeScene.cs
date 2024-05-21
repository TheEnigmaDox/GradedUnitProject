using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MazeScene : MonoBehaviour
{
    float toxAmount = 0;

    float mazeTimer = 0;

    float easyTimer = 120;
    float mediumTimer = 60;
    float hardTimer = 30;

    public TMP_Text timerText;

    public Camera mainCam;

    Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<Stats>();

        if (stats != null)
        {
            toxAmount = stats.toxLevel; 
        }

        if (toxAmount < 25)
        {
            mainCam.orthographicSize = 7;
            mazeTimer = easyTimer;
        }
        else if (toxAmount > 25 && toxAmount < 75)
        {
            mainCam.orthographicSize = 5;
            mazeTimer = mediumTimer;
        }
        else if (toxAmount > 75)
        {
            mainCam.orthographicSize = 2;
            mazeTimer = hardTimer;
        }

        Debug.Log("Maze Timer : " + mazeTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (mazeTimer > 0)
        {
            mazeTimer -= Time.deltaTime;
            UpdateTimer(mazeTimer);
        }
        else if(mazeTimer <= 0)
        {
            stats.survive = false;
            SceneManager.LoadScene(4);
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
