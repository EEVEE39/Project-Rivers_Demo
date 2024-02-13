using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcInteract : MonoBehaviour
{
    public bool playerInHitbox;
    public encounterHandlerScript encounterHandlerScript;
    public dialougeManager dialougeManager;

    public Dialouge dialouge;

    void Start(){
        encounterHandlerScript = FindObjectOfType<encounterHandlerScript>();
        dialougeManager = FindObjectOfType<dialougeManager>();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Z) && playerInHitbox && dialougeManager.dialouging == false){
            dialougeManager.startDialouge(dialouge);
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
