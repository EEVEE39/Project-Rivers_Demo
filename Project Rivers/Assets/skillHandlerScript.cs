using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillHandlerScript : MonoBehaviour
{

    public battleHandlerScript battleHandlerScript;
    public string currentSkill;

    public void useSkill(string skillUsed){
        switch(skillUsed){
            case "repair":
                if(battleHandlerScript.watt >= 20f){
                battleHandlerScript.playerHp += 25;
                battleHandlerScript.watt -= 20f;
                battleHandlerScript.currentPhase = "enemy";
                }
                break;
            case "shock":
                if(battleHandlerScript.watt >= 50f){
                currentSkill = skillUsed;
                battleHandlerScript.currentSelected = "skillSelect";
                }
                break;
            case "shock finish":
                battleHandlerScript.watt -= 50f;
                battleHandlerScript.enemyHp[battleHandlerScript.enemyTargeted] -= 40;
                battleHandlerScript.currentPhase = "enemy";
                break;
            case "soothing music":
                if(battleHandlerScript.watt >= 40f){
                currentSkill = skillUsed;
                battleHandlerScript.currentSelected = "skillSelect";
                }
                break;
            case "soothing music finish":
                battleHandlerScript.watt -= 40f;
                battleHandlerScript.enemyFp[battleHandlerScript.enemyTargeted] += 35f;
                battleHandlerScript.currentPhase = "enemy";
                break;
        }
    }
}
//sex
