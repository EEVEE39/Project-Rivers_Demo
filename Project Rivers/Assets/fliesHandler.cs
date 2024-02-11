using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fliesHandler : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;

    void Start()
    {
        if(gameObject.transform.position.x == 2.5f && gameObject.transform.position.y == -2.5f)
            movement.x = -1;
        if(gameObject.transform.position.x == -2.5f && gameObject.transform.position.y == -2.5f)
            movement.x = 1;
        if(gameObject.transform.position.x == 0f && gameObject.transform.position.y == -5f)
            movement.y = 1;
        if(gameObject.transform.position.x == 0f && gameObject.transform.position.y == 0f)
            movement.y = -1;
       
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
