using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcInteract : MonoBehaviour
{
    public List<string> battleEnemies = new List<string>();
    public bool playerInHitbox;
    public bool isBoss;
    public encounterHandlerScript encounterHandlerScript;

    void Start(){
        encounterHandlerScript = FindObjectOfType<encounterHandlerScript>();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Z) && playerInHitbox){
            encounterHandlerScript.isBoss = isBoss;
            encounterHandlerScript.StartBattle(battleEnemies);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            playerInHitbox = true;
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.name == "player")
            playerInHitbox = false;
    }
}
