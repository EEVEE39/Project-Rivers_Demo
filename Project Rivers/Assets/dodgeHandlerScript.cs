using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dodgeHandlerScript : MonoBehaviour
{

    public battleHandlerScript battleHandlerScript;
    public GameObject player;
    public string currentDodge;

    public float timer;
    public float timeLimit;
    public bool currentlyDodging;
    public float nextSpawn = 0f;
    public float spawnFrequncy;

    public List<GameObject> dodgeThings = new List<GameObject>();
    public GameObject testBullet;

    public GameObject pufferSpike;
    public GameObject pufferfish;
    public GameObject hook;

    public GameObject zeis;
    public GameObject zeisblocker;

    //public GameObject enemySprite;
    public Sprite gilligan;
    public Sprite mansquito;
    public Sprite germa;

    public void InitiateDodge(string dodgeInitiated){
        switch (dodgeInitiated){
            case "test":
                timeLimit = 8f;
                spawnFrequncy = 1f;
                currentlyDodging = true;
                player.transform.position = new Vector2(0f,-2.5f);
                break; 
             case "scythe":
                timeLimit = 8;
                spawnFrequncy = 1f;
                currentlyDodging = true;
                player.transform.position = new Vector2(0f,-4f);
                dodgeThings.Add(Instantiate(zeisblocker, new Vector2(0f, -4.991f), Quaternion.identity));
                //enemySprite.GetComponent<UnityEngine.SpriteRenderer> ().sprite = germa;
                //enemySprite.transform.position = new Vector3(0f, 4.79f, -1f);
                break; 
            case "pufferfish":
                timeLimit = 10f;
                spawnFrequncy = 0.2f;
                currentlyDodging = true;
                player.transform.position = new Vector2(0f,-4f);
                dodgeThings.Add(Instantiate(pufferfish, new Vector3(0f, -2.61f, -2f), Quaternion.identity));
                dodgeThings.Add(Instantiate(hook, new Vector3(0f, -1.549f, -1f), Quaternion.identity));
                //enemySprite.GetComponent<UnityEngine.SpriteRenderer> ().sprite = gilligan;
                //enemySprite.transform.position = new Vector3(6.62f, 4.79f, -1f);
                break; 
        }
        currentDodge = dodgeInitiated;
    }

    void FixedUpdate ()
    {
        if(currentlyDodging == true){
            switch(currentDodge){
                case "test":
                    if(timer > nextSpawn){
                        
                        nextSpawn += spawnFrequncy;
                        }
                    break;
                case "scythe":
                    if(timer > nextSpawn){
                        dodgeThings.Add(Instantiate(zeis, new Vector3(1f, 0f, -1f), Quaternion.identity));
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
                currentlyDodging = false;
            }
        }
    }
}
