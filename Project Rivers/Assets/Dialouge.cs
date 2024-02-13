using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge
{

    public string name;
    public Sprite sprite;

    [TextArea(3, 10)]
    public List<string> sentences = new List<string>();

    public List<string> enemies = new List<string>();
}
