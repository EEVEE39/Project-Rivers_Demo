using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swatterHandler : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float opacity;
    Vector3 newScale;
    public float timer = 0;
    public bool takingDamage;
    public bool gracing;
    Vector2 movement;
    public Rigidbody2D rb;

    void Start()
    {
        opacity = 0f;
        Vector3 newScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, opacity);
        movement.y = 1;
       
    }

    void FixedUpdate()
    {
        
        if(timer <= 0f){
            opacity += Time.fixedDeltaTime * 2f;
            if(opacity > 1f){
                opacity = 1f;
            }
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, opacity);
            Vector2 changeScale = new Vector2(transform.localScale.x - 2f * Time.fixedDeltaTime, transform.localScale.y - 2f * Time.fixedDeltaTime );
            transform.localScale = changeScale;
            rb.MovePosition(rb.position + movement * 2 * Time.fixedDeltaTime);

        }
        if(opacity >= 1f){
            timer += Time.fixedDeltaTime;
        }
        if(timer >= 0.4f){
            FindObjectOfType<battleHandlerScript>().takingDamage = false;
            FindObjectOfType<battleHandlerScript>().gracing = false;
            Destroy(gameObject);
        }
        if(timer > 0){
            if(takingDamage)
                FindObjectOfType<battleHandlerScript>().takingDamage = true;
            if(gracing)
                FindObjectOfType<battleHandlerScript>().gracing = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            takingDamage = true;
        else{
            if(collision.gameObject.name == "graceArea")
            gracing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            takingDamage = false;
        else {
            if(collision.gameObject.name == "graceArea")
            gracing = false;
        } 
    }
}
