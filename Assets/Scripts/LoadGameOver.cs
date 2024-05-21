using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOver : MonoBehaviour
{
    Stats stats;
    private void Start()
    {
        stats = FindObjectOfType<Stats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stats.survive = true;
            SceneManager.LoadScene(4);
            
        }
        
    }


}
