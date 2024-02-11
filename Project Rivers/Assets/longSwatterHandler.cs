using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longSwatterHandler : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;

    void Start()
    {
        movement.x = -1f;
       
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * 7 * Time.fixedDeltaTime);
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