using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This attribute makes the class serializable, which means it can be saved and loaded in the Unity Editor
[Serializable]
public class Dialogue
{
    // The name of the character speaking the dialogue
    public string speakerName;

    // The name of the narcotic involved in the dialogue
    public string narcotic;

    // An array of sentences in the dialogue. The TextArea attribute allows for multi-line editing in the Unity Editor
    [TextArea(3, 10)]
    public string[] sentences;
}
