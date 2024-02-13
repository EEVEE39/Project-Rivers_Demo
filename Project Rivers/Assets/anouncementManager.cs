using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anouncementManager : MonoBehaviour
{
    public encounterHandlerScript encounterHandlerScript;
    public dialougeManager dialougeManager;

    public bool playerInHitbox;

    public Dialouge dialouge;

    void Start(){

        encounterHandlerScript = FindObjectOfType<encounterHandlerScript>();
        dialougeManager = FindObjectOfType<dialougeManager>();
        playerInHitbox = true;
    }

    void Update(){
        if(playerInHitbox && dialougeManager.dialouging == false){
            if(encounterHandlerScript.germaWin == false && encounterHandlerScript.gilliganWin == false && encounterHandlerScript.jeffWin == false){
                dialougeManager.startDialouge(dialouge);
                playerInHitbox = false;
            }
            if(encounterHandlerScript.germaWin == true && encounterHandlerScript.gilliganWin == true && encounterHandlerScript.jeffWin == true && encounterHandlerScript.isBoss == false){
                dialougeManager.startDialouge(dialouge);
                playerInHitbox = false;
            }
        }    
    }
}
