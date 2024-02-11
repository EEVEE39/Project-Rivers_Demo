using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piranhaHandler : MonoBehaviour
{
    Vector2 movement;
    public float speed;
    public Rigidbody2D rb;
    public float startX;
    public SpriteRenderer spriteRenderer;

    void Start()
    { 
        startX = Random.Range(-1.885f, 1.885f);
        transform.position = new Vector3(startX, -4.42f, 0f);
        speed = Random.Range(7f,9f);
        movement.y = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipY = false;
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        speed -= 10 * Time.fixedDeltaTime;
        if(speed < 0){
            spriteRenderer.flipY = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            FindObjectOfType<battleHandlerScript>().takingDamage = true;
        else{
            if(collision.gameObject.name == "graceArea")
            FindObjectOfType<battleHandlerScript>().gracing = true;
        }
        if(collision.gameObject.CompareTag("wall")){
           // Destroy(gameObject);
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
