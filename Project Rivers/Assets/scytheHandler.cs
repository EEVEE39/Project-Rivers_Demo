using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scytheHandler : MonoBehaviour
{
    Vector2 movement;
    public float currentRotation;
    public Rigidbody2D rb;
    public int aligned;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        movement.y -= 1;
        movement.x += 0.1f;
        currentRotation = -90f;
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        aligned = Random.Range(0,2);
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (aligned == 0){
            transform.position = new Vector3(-0.85f, 0f, -1f);
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            movement.x *= -1;
            transform.localScale = newScale;
        }
        else
            transform.position = new Vector3(0.85f, 0f, -1f);
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        rb.MovePosition(rb.position + movement * 8 * Time.fixedDeltaTime);
        if(aligned == 0)
            currentRotation += -300 * Time.fixedDeltaTime;
        else
            currentRotation += 300 * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            FindObjectOfType<battleHandlerScript>().takingDamage = true;
        else{
            if(collision.gameObject.name == "graceArea")
            FindObjectOfType<battleHandlerScript>().gracing = true;
        }
        if(collision.gameObject.CompareTag("scytheblocker"))
            Destroy(gameObject);
        
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
