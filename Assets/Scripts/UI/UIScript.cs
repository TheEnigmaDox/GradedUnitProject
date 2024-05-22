using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Reference to the intoxication slider in the UI
    public Slider intoxicationSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Set the maximum value of the intoxication slider to 100 and its initial value to 0
        intoxicationSlider.maxValue = 100;
        intoxicationSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the intoxication value over time
        intoxicationSlider.value -= 1 * Time.deltaTime;
    }

    // Method to add intoxication to the slider
    public void AddIntoxication(float intoxAmount)
    {
        // Increase the intoxication value by the specified amount
        intoxicationSlider.value += intoxAmount;
    }
}
