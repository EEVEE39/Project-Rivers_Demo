using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy {

    public string name;
    public int hp;
    public int atk;
    public int def;

    public string act1;
    public string act2;
    public string act1Description;
    public string act2Description;

    public string dodge1;
    public string dodge2;
}

public class enemySystem : MonoBehaviour {

    public List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
       
    }
}