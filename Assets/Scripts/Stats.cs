using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float toxLevel = 0f;
    public bool survive;

    UIScript uiScript;

    public static Stats statsInstance;

    private void Awake()
    {
        if (statsInstance != null && statsInstance != this)
        {
            Destroy(statsInstance);
        }
        else
        {
            statsInstance = this;
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        uiScript = FindObjectOfType<UIScript>();

        Debug.Log(toxLevel);
    }

    // Update is called once per frame
    void Update()
    {
        toxLevel = uiScript.intoxicationSlider.value;

        Debug.Log("Survive : " + survive);
    }
}