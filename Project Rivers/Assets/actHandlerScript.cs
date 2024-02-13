using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actHandlerScript : MonoBehaviour
{
    public battleHandlerScript battleHandlerScript;
    public float timer = 0f;
    public float maxTimer;
    public bool activateTimer = false;
    public string currentAct;

    public GameObject fly;
    public GameObject bugspray;
    public GameObject fishingRod;
    public GameObject fishingHook;
    public GameObject fish;
    


    public List<GameObject> actThings = new List<GameObject>();

    public void useAct(string actId){
        currentAct = actId;
        Debug.Log(actId);
        switch (actId){
            case "check":
                battleHandlerScript.isChecked[battleHandlerScript.enemyTargeted] = true;
                battleHandlerScript.currentPhase = "enemy";
                break; 
            case "spare":
                if(battleHandlerScript.enemyFp[battleHandlerScript.enemyTargeted] >= 100f)
                    battleHandlerScript.isSpared[battleHandlerScript.enemyTargeted] = true;
                    battleHandlerScript.currentPhase = "enemy";
                break;
            case "moldy fruit":
                battleHandlerScript.enemyFp[battleHandlerScript.enemyTargeted] += 10;
                battleHandlerScript.currentPhase = "enemy";
                break;
            case "bug spray":
                battleHandlerScript.currentSelected = "actMinigame";
                actThings.Add(Instantiate(fly, new Vector2(0, 0), Quaternion.identity));
                actThings.Add(Instantiate(bugspray, new Vector2(0, 0), Quaternion.identity));
                maxTimer = 5f;
                activateTimer = true;
                break;
            case "bug spray finish":
                battleHandlerScript.currentPhase = "enemy";
                for(int i = 0; i < actThings.Count; i++){
                    Destroy(actThings[i]);
                }
                activateTimer = false;
                timer = 0f;
                battleHandlerScript.selectButton();
                break;
            case "bait":
                battleHandlerScript.enemyFp[battleHandlerScript.enemyTargeted] += 10;
                battleHandlerScript.currentPhase = "enemy";
                break;
            case "catch":
                battleHandlerScript.currentSelected = "actMinigame";
                actThings.Add(Instantiate(fish, new Vector2(0, -4), Quaternion.identity));
                actThings.Add(Instantiate(fishingHook, new Vector2(0.0822f, 6.27f), Quaternion.identity));
                actThings.Add(Instantiate(fishingRod, new Vector2(0.59f, 2.499f), Quaternion.identity));
                break;
            case "catch succeed":
                for(int i = 0; i < actThings.Count; i++){
                    Destroy(actThings[i]);
                }
                battleHandlerScript.enemyFp[battleHandlerScript.enemyTargeted] += 35;
                battleHandlerScript.currentPhase = "enemy";
                battleHandlerScript.selectButton();
                break;
            case "catch fail":
                for(int i = 0; i < actThings.Count; i++){
                    Destroy(actThings[i]);
                }
                battleHandlerScript.currentPhase = "enemy";
                battleHandlerScript.selectButton();
                break;
            case "moldy cheese":
                battleHandlerScript.enemyFp[battleHandlerScript.enemyTargeted] += 25;
                battleHandlerScript.currentPhase = "enemy";
                break;
            case "cheddar cheese":
                battleHandlerScript.enemyFp[battleHandlerScript.enemyTargeted] -= 10;
                battleHandlerScript.currentPhase = "enemy";
                break;
        }
    }
    void FixedUpdate ()
    {
        if(activateTimer == true){
            timer += Time.fixedDeltaTime;
            if(timer >= maxTimer){
                useAct(currentAct + " finish");
            }
        }
    }
}
