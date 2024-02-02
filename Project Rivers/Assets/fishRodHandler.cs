using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishRodHandler : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;
    public bool hooking = false;

    void Start()
    {
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Z)){
            hooking = true;
        }
    }

    void FixedUpdate()
    {
        if(hooking == false)
            rb.MovePosition(rb.position + movement * 7 * Time.fixedDeltaTime);
    }

    
}   
