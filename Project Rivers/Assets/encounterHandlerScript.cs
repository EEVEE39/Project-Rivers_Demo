using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encounterHandlerScript : MonoBehaviour
{
    public battleHandlerScript battleHandlerScript;
    public List<string> encounter = new List<string>();

    void Start()
    {
        battleHandlerScript.EnemySelect(encounter);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
