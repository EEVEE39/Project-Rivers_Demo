using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pufferSpikeHandler : MonoBehaviour
{
    
    Vector2 movement;
    public float currentRotation;
    public Rigidbody2D rb;

    void Start()
    {
        movement.x = Random.Range(-1f, 1f); 
        movement.y = Random.Range(-1f, 1f); 
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y)){
            movement.x /= Mathf.Abs(movement.x);
            movement.y /= Mathf.Abs(movement.x);
        }
        if (Mathf.Abs(movement.x) < Mathf.Abs(movement.y)){
            movement.x /= Mathf.Abs(movement.y);
            movement.y /= Mathf.Abs(movement.y);
        }
        if(movement.x == 1f){
            currentRotation = 0f + 45f * movement.y;
        }
        if(movement.y == 1f){
            currentRotation = 90f + -45f * movement.x;
        }
        if(movement.x == -1f){
            currentRotation = 180f + -45f * movement.y;
        }
        if(movement.y == -1f){
            currentRotation = 270f  + 45f * movement.x;
        }
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * 2 * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            FindObjectOfType<battleHandlerScript>().takingDamage = true;
        else{
            if(collision.gameObject.name == "graceArea")
            FindObjectOfType<battleHandlerScript>().gracing = true;
        }
        if(collision.gameObject.CompareTag("wall")){
            Destroy(gameObject);
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
