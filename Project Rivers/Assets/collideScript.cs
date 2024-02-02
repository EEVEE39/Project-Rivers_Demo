using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideScript : MonoBehaviour
{
    public battleHandlerScript battleHandlerScript;


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            battleHandlerScript.takingDamage = true;
        else{
            if(collision.gameObject.name == "graceArea")
            battleHandlerScript.gracing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            battleHandlerScript.takingDamage = false;
        else {
            if(collision.gameObject.name == "graceArea")
            battleHandlerScript.gracing = false;
        }
    }
}
