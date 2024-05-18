using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Slider intoxicationSlider;

    // Start is called before the first frame update
    void Start()
    {
        intoxicationSlider.maxValue = 100;
        intoxicationSlider.value = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        intoxicationSlider.value -= 1 * Time.deltaTime;
    }

    public void AddIntoxication(float intoxAmount)
    {
        intoxicationSlider.value += intoxAmount;
    }
}
