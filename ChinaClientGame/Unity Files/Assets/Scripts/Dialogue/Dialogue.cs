using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Makes it editable in Unity
public class Dialogue
{
    public string title;
    [TextArea(1, 10)] // Mininum and maximum lines that can be written
    public string[] sentences;
}
