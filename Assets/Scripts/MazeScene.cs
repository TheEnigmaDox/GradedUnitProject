using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScene : MonoBehaviour
{
    float toxAmount = 0;

    public Camera mainCam;

    Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<Stats>();

        toxAmount = stats.toxLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if(toxAmount < 25)
        {
            mainCam.orthographicSize = 7;
        }
        else if(toxAmount > 25 && toxAmount < 75)
        {
            mainCam.orthographicSize = 5;
        }
        else if(toxAmount > 75)
        {
            mainCam.orthographicSize = 2;
        }

        Debug.Log("Maze Scene Tox Level : " + toxAmount);
    }
}
