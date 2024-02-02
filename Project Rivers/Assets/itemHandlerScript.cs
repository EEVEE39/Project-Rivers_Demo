using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHandlerScript : MonoBehaviour
{

    public battleHandlerScript battleHandlerScript;

    public void useItem(string itemUsed)
    {
        switch (itemUsed){
            case "healing pills":
                battleHandlerScript.playerHp += 25;
                if(battleHandlerScript.playerHp > battleHandlerScript.playerMaxHp)
                battleHandlerScript.playerHp = battleHandlerScript.playerMaxHp;
                break;
            case "battery pack":
                battleHandlerScript.watt += 30f;
                if(battleHandlerScript.watt > 100f)
                battleHandlerScript.watt = 100f;
                break;
        }
    }
}
