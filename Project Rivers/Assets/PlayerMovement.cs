using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float defaultSpeed;
    public float defaultSprintSpeed;
    public bool sprinting;
    public bool canSprint;
    public Rigidbody2D rb;

    public Vector2 movement;

    public Animator animator;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.X) && canSprint == false){
            sprinting = true;
        }
        if(Input.GetKeyUp(KeyCode.X)) {
            sprinting = false;
        }
        if(movement.x != 0 && movement.y != 0 && sprinting == true){
        if(sprinting == true){
            moveSpeed = defaultSprintSpeed / 1.4f;
        }
        else{
            moveSpeed = defaultSpeed / 1.4f;
        }
        }
        else {
            if(sprinting){
            moveSpeed = defaultSprintSpeed;
        }
        else{
            moveSpeed = defaultSpeed;
        }
        }
        if(defaultSpeed > 0){
        animator.SetFloat("horizontal",movement.x);
        animator.SetFloat("vertical",movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
