using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratHandler : MonoBehaviour
{
    Vector2 movement;
    public Rigidbody2D rb;
    public int randomSpawn;
    public dodgeHandlerScript dodgeHandlerScript;
    public Vector2 deltaDistance;
    public float currentRotation;
    public bool shmoove = false;

    void Start()
    {
        dodgeHandlerScript = FindObjectOfType<dodgeHandlerScript>();
        randomSpawn = Random.Range(0,4);
        switch (randomSpawn){
            case 0:
                transform.position = new Vector3(2f, dodgeHandlerScript.playerPosition.y, 1f);
                movement.x = -1;
                break;
            case 1:
                transform.position = new Vector3(dodgeHandlerScript.playerPosition.x, -4.5f, 1f);
                movement.y = 1;
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 2:
                transform.position = new Vector3(-2f, dodgeHandlerScript.playerPosition.y, 1f);
                movement.x = 1;
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case 3:
                transform.position = new Vector3(dodgeHandlerScript.playerPosition.x, -0.5f, 1f);
                movement.y = -1;
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }

    void FixedUpdate()
    {
        if(shmoove)
            rb.MovePosition(rb.position + movement * 10 * Time.fixedDeltaTime);
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
