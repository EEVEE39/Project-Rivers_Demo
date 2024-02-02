using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("fish"))
            FindObjectOfType<actHandlerScript>().useAct("catch succeed");
        if(collision.gameObject.name == "wall (2)")
            FindObjectOfType<actHandlerScript>().useAct("catch fail"); 
    }   

    public Rigidbody2D rb;
    Vector2 movement;
    public bool hooking = false;

    void Start()
    {
    }

    void Update()
    {
        if(hooking == false)
        movement.x = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Z)){
            hooking = true;
            movement. x = 0;
            movement.y = -1;
        }
    }

    void FixedUpdate()
    {
            rb.MovePosition(rb.position + movement * 7 * Time.fixedDeltaTime);
    }
}
