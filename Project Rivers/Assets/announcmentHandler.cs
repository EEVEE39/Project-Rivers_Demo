using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class announcmentHandler : MonoBehaviour
{
    public bool playerInHitbox;
    public bool isBoss;
    public encounterHandlerScript encounterHandlerScript;
    public dialougeManager dialougeManager;

    public Dialouge dialouge;

    void Start(){
        encounterHandlerScript = FindObjectOfType<encounterHandlerScript>();
        dialougeManager = FindObjectOfType<dialougeManager>();
    }

    void Update()
    {
        if(dialouge.annoucment == true && playerInHitbox && dialougeManager.dialouging == false){
            dialougeManager.startDialouge(dialouge);
        }
        if(dialougeManager.dialouging == true && dialougeManager.currentSentence > 0 && dialouge.annoucment == true)
            Destroy(gameObject);
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