using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishHandler : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;

    void Start()
    {
        movement.x = 1;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * 10 * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("wall")){
            movement.x *= -1;
        }   
    }
}
