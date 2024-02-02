using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHandlerTEST : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    
    void Start()
    {
        movement.x = -1;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * 3 * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            FindObjectOfType<battleHandlerScript>().takingDamage = true;
        else{
            if(collision.gameObject.name == "graceArea")
            FindObjectOfType<battleHandlerScript>().gracing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            FindObjectOfType<battleHandlerScript>().takingDamage = false;
        else {
            if(collision.gameObject.name == "graceArea")
            FindObjectOfType<battleHandlerScript>().gracing = false;
        }
    }
}
