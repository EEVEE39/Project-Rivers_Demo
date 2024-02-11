using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dodgeHandlerScript : MonoBehaviour
{

    public battleHandlerScript battleHandlerScript;
    public GameObject player;
    public string currentDodge;

    public string battleAreaType;
    public Sprite defaultBattleArea;
    public Sprite longBattleArea;
    public GameObject wallEast;
    public GameObject wallWest;
    public GameObject battleArea;

    public float ranNum;
    public float timer;
    public float timeLimit;
    public bool currentlyDodging;
    public float nextSpawn = 0f;
    public float nextSpawn2 = 0f;
    public float spawnFrequncy;
    public float spawnFrequncy2;

    public List<GameObject> dodgeThings = new List<GameObject>();
    public GameObject testBullet;

    public GameObject pufferSpike;
    public GameObject pufferfish;
    public GameObject hook;
    public GameObject rope;
    public GameObject piranha;
    public GameObject hookPiranha;

    public GameObject zeis;
    public GameObject zeisblocker;
    public int scytheDirection;
    public int oldScytheDirection;
    public GameObject rat;

    public GameObject swatter;
    public GameObject swatterUp;
    public GameObject swatterDown;
    public GameObject fly;
 
    public GameObject enemySprite;
    public Sprite gilligan;
    public Sprite mansquito;
    public Sprite germa;

    public Vector2 playerPosition;

    public float x = 0f;

    public void InitiateDodge(string dodgeInitiated){
        if(dodgeInitiated == currentDodge && dodgeInitiated != "test"){
            battleHandlerScript.startEnemyPhase();
            return;
        }

        switch (dodgeInitiated){
            case "test":
                timeLimit = 10f;
                spawnFrequncy = 0.75f;
                currentlyDodging = true;
                player.transform.position = new Vector2(0f,-2.5f);
                enemySprite.GetComponent<UnityEngine.SpriteRenderer> ().sprite = mansquito;
                enemySprite.transform.position = new Vector3(0f, 1.8f, -1f);
                break;
            case "swatter":
                timeLimit = 10f;
                spawnFrequncy = 1f;
                spawnFrequncy2 = 1f;
                nextSpawn = 0.5f;
                currentlyDodging = true;
                player.transform.position = new Vector2(-1f,-1.5f);
                enemySprite.GetComponent<UnityEngine.SpriteRenderer> ().sprite = mansquito;
                enemySprite.transform.position = new Vector3(0f, 1.8f, -1f);
                break; 
            case "long swatter":
                timeLimit = 10f;
                spawnFrequncy = 0.75f;
                currentlyDodging = true;
                player.transform.position = new Vector3(-5f,-2.5f,-1f);
                enemySprite.GetComponent<UnityEngine.SpriteRenderer> ().sprite = mansquito;
                enemySprite.transform.position = new Vector3(0f, 1.8f, -1f);
                battleAreaType = "long";
                break;
            case "scythe":
                timeLimit = 10f;
                spawnFrequncy = 1f;
                currentlyDodging = true;
                player.transform.position = new Vector2(0f,-4f);
                dodgeThings.Add(Instantiate(zeisblocker, new Vector2(0f, -4.991f), Quaternion.identity));
                enemySprite.GetComponent<UnityEngine.SpriteRenderer> ().sprite = germa;
                enemySprite.transform.position = new Vector3(0.69333f, 1.8f, -1f);
                x = 0.69333f;
                break; 
            case "rats":
                timeLimit = 10f;
                spawnFrequncy = 1f;
                currentlyDodging = true;
                player.transform.position = new Vector2(0f,-2.5f);
                enemySprite.GetComponent<UnityEngine.SpriteRenderer> ().sprite = germa;
                enemySprite.transform.position = new Vector3(0f, 1.8f, -1f);
                break;
            case "pufferfish":
                timeLimit = 10f;
                spawnFrequncy = 0.2f;
                currentlyDodging = true;
                player.transform.position = new Vector2(0f,-4f);
                dodgeThings.Add(Instantiate(pufferfish, new Vector3(0f, -2.61f, -2f), Quaternion.identity));
                dodgeThings.Add(Instantiate(hook, new Vector3(-0.022f, -1.738f, -1f), Quaternion.identity));
                dodgeThings.Add(Instantiate(rope, new Vector3(-0.105f, -0.035f, -1f), Quaternion.identity));
                enemySprite.GetComponent<UnityEngine.SpriteRenderer>().sprite = gilligan;
                enemySprite.transform.position = new Vector3(1.836f, 1.8f, -1f);
                break; 
            case "piranha":
                timeLimit = 10f;
                spawnFrequncy = 0.5f;
                currentlyDodging = true;
                player.transform.position = new Vector2(0f,-1f);
                dodgeThings.Add(Instantiate(hookPiranha, new Vector3(0.1f, -2.61f, -2f), Quaternion.identity));
                dodgeThings.Add(Instantiate(hook, new Vector3(-0.022f, -1.738f, -1f), Quaternion.identity));
                dodgeThings.Add(Instantiate(rope, new Vector3(-0.105f, -0.035f, -1f), Quaternion.identity));
                enemySprite.GetComponent<UnityEngine.SpriteRenderer>().sprite = gilligan;
                enemySprite.transform.position = new Vector3(1.836f, 1.8f, -1f);
                break;
        }
        currentDodge = dodgeInitiated;
    }

    void Update(){
        playerPosition = new Vector2(player.transform.position.x,player.transform.position.y);
        if(battleAreaType == "long"){
            battleArea.GetComponent<UnityEngine.SpriteRenderer>().sprite = longBattleArea;
            wallEast.SetActive(false);
            wallWest.SetActive(false);
        }
        else{
            battleArea.GetComponent<UnityEngine.SpriteRenderer>().sprite = defaultBattleArea;
            wallEast.SetActive(true);
            wallWest.SetActive(true);
        }
    }

    void FixedUpdate ()
    {
        if(currentlyDodging == true){
            switch(currentDodge){
                case "test":
                    if(timer >= nextSpawn){
                        nextSpawn += spawnFrequncy;
                    }
                    break;
                case "swatter":
                    if(timer > nextSpawn){
                        dodgeThings.Add(Instantiate(swatter, new Vector3(player.transform.position.x, player.transform.position.y - 2.25f, -1f), Quaternion.identity));
                        nextSpawn += spawnFrequncy;
                        }
                    if(timer > nextSpawn2){
                        dodgeThings.Add(Instantiate(fly, new Vector3(2.5f, -2.5f, 1f), Quaternion.identity));
                        dodgeThings.Add(Instantiate(fly, new Vector3(-2.5f, -2.5f, 1f), Quaternion.identity));
                        dodgeThings.Add(Instantiate(fly, new Vector3(0f, -5f, 1f), Quaternion.identity));
                        dodgeThings.Add(Instantiate(fly, new Vector3(0f, 0f, 1f), Quaternion.identity));
                        nextSpawn2 += spawnFrequncy2;
                    }
                    break;
                case "long swatter":
                    if(timer >= nextSpawn){
                        ranNum = Random.Range(-5.27f, -2.5f);
                        dodgeThings.Add(Instantiate(swatterUp, new Vector3(6f, ranNum, -1f), Quaternion.identity));
                        dodgeThings.Add(Instantiate(swatterDown, new Vector3(6f, ranNum + 2.665f, -1f), Quaternion.identity));
                        nextSpawn += spawnFrequncy;
                    }
                    break;
                case "scythe":
                    if(timer + 0.25f > nextSpawn){
                        
                        enemySprite.transform.position = new Vector3(x, 1.8f, -1f);
                        if(scytheDirection == 0){  
                            x -= 5.5f * Time.fixedDeltaTime;
                        }
                        else{
                            x += 5.5f * Time.fixedDeltaTime;
                        }
                    }
                    if(timer + 0.75 > nextSpawn && timer + 0.5 < nextSpawn && timer >= 1){
                        enemySprite.transform.position = new Vector3(x, 1.8f, -1f);
                        if(oldScytheDirection == 0){  
                            x += 5.5f * Time.fixedDeltaTime;
                        }
                        else{
                            x -= 5.5f * Time.fixedDeltaTime;
                        }
                    }
                    if(timer + 0.5 > nextSpawn && timer + 0.25 < nextSpawn && timer >= 1){
                        x = 0.69333f;
                        enemySprite.transform.position = new Vector3(x, 1.8f, -1f);
                    }
                    if(timer > nextSpawn){
                        if(timer >= 1)
                            FindObjectOfType<scytheHandler>().visible = true;
                        oldScytheDirection = scytheDirection;
                        dodgeThings.Add(Instantiate(zeis, new Vector3(1f, 0f, -1f), Quaternion.identity));
                        nextSpawn += spawnFrequncy;
                        }
                    break;
                case "rats":
                    if(timer + 0.5 > nextSpawn){
                        if(timer >= 0.5)
                            FindObjectOfType<ratHandler>().shmoove = true;
                        }
                    if(timer >= nextSpawn){
                        dodgeThings.Add(Instantiate(rat, new Vector3(player.transform.position.x, player.transform.position.y - 2.25f, -1f), Quaternion.identity));
                        nextSpawn += spawnFrequncy;
                        }
                    break;
                case "pufferfish":
                    if(timer > nextSpawn){
                        dodgeThings.Add(Instantiate(pufferSpike, new Vector2(0f, -2.5f), Quaternion.identity));
                        dodgeThings.Add(Instantiate(pufferSpike, new Vector2(0f, -2.5f), Quaternion.identity));
                        dodgeThings.Add(Instantiate(pufferSpike, new Vector2(0f, -2.5f), Quaternion.identity));
                        dodgeThings.Add(Instantiate(pufferSpike, new Vector2(0f, -2.5f), Quaternion.identity));
                        nextSpawn += spawnFrequncy;
                        }
                    break;
                case "piranha":
                    if(timer > nextSpawn){
                       dodgeThings.Add(Instantiate(piranha, new Vector3(1f, 0f, -1f), Quaternion.identity));
                       dodgeThings.Add(Instantiate(piranha, new Vector3(1f, 0f, -1f), Quaternion.identity));
                        nextSpawn += spawnFrequncy;
                        }
                    break;
            }
            timer += Time.fixedDeltaTime;
            if(timer >= timeLimit || battleHandlerScript.currentPhase != "enemy"){
                for(int i = 0; i < dodgeThings.Count; i++){
                    Destroy(dodgeThings[i]);
                }
                battleHandlerScript.currentPhase = "player";
                timeLimit = 0;
                timer = 0;
                nextSpawn = 0;
                nextSpawn2 = 0;
                battleAreaType = "default";
                currentlyDodging = false;
            }
        }
    }
}
