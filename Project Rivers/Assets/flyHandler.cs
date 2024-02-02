using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyHandler : MonoBehaviour
{
    public float flyTimer = 0f;
    public float flyLimit = 1f;
    public Rigidbody2D rb;
    public bool spraying = false;

    Vector2 movement;
    
    void Start()
    {
        ChangeDirection();
        flyLimit = Random.Range(0.3f,0.5f);
    }

    void FixedUpdate()
    {
        flyTimer += Time.fixedDeltaTime;
        if(flyTimer >= flyLimit){
            flyLimit = Random.Range(0.3f,0.5f);
            ChangeDirection();
            flyTimer = 0f;
        }
        rb.MovePosition(rb.position + movement * 7 * Time.fixedDeltaTime);
        if(spraying == true)
            FindObjectOfType<battleHandlerScript>().enemyFp[FindObjectOfType<battleHandlerScript>().enemyTargeted] += Time.fixedDeltaTime * 50;
    }

    void ChangeDirection()
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("wall")){
            movement.x *= -1;
            movement.y *= -1;
        }
        if(collision.gameObject.CompareTag("bugspray"))
            spraying = true;    
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bugspray"))
            spraying = false;    
    }
}
