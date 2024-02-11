using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticleManager : MonoBehaviour
{
    public dodgeHandlerScript dodgeHandlerScript;

    void Start()
    {
        dodgeHandlerScript = FindObjectOfType<dodgeHandlerScript>();
    }
    void Update()
    {
        transform.position = new Vector2(dodgeHandlerScript.playerPosition.x,dodgeHandlerScript.playerPosition.y);
        Debug.Log(transform.position);
    }
}
