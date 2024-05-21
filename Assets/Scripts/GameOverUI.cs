using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverUI : MonoBehaviour
{
    public TMP_Text game_over_text;
    Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public void LoadTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
       Application.Quit();
    }
}
