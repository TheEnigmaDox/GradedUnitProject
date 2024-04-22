using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    TommyController tommyController;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    
        DontDestroyOnLoad(this);

        tommyController = FindObjectOfType<TommyController>();
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;
    }
}
