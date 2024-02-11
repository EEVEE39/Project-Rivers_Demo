using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class battleHandlerScript : MonoBehaviour
{
    [Header ("Refrences")]
    public GameObject battleUiHandler;
    public encounterHandlerScript encounterHandlerScript;
    public enemySystem enemySystem;
    public playerStatsHandler playerStatsHandler;
    public actHandlerScript actHandlerScript;
    public GameObject player; 
    public SpriteRenderer playerSprite;
    public skillHandlerScript skillHandlerScript;
    public itemHandlerScript itemHandlerScript;
    public dodgeHandlerScript dodgeHandlerScript;

    [Header ("Enemy Stats")]
    public List<int> enemyAtk = new List<int>();
    public List<int> enemyDef = new List<int>();
    public List<int> enemyMaxHp = new List<int>();
    public List<int> enemyHp = new List<int>();
    public List<float> enemyFp = new List<float>();
    public List<bool> isSpared = new List<bool>();
    public List<bool> isDead = new List<bool>();
    public bool allDead = false;
    public bool allSpared = false;

    [Header ("Player Stats")]
    public int playerAtk;
    public int playerDef;
    public int playerMaxHp;
    public int playerHp;
    public int playerChar;
    public int playerGa;
    public int playerIframe;
    public int playerLuck;
    public int playerLvl;
    public float watt;

    [Header ("Menu Vars")]
    public int currentButtonSelect = 0;
    public int currentPage = 0;
    public int maxPage = 0;
    public string currentSelected = "menu";
    public int maxSelect = 4;
    public string currentPhase = "player";
    public int enemyTargeted = 0;

    [Header ("Enemy Phase")]
    public bool canBeHit;
    public float IframeDuration;
    public bool takingDamage;
    public bool gracing;
    public string dodgeSelected;
    public int enemyAttacking;

    [Header ("Options")]
    public List<string> currentEnemies = new List<string>();
    public List<string> currentActs1 = new List<string>();
    public List<string> currentActs2 = new List<string>();
    public List<string> currentActsDescription1 = new List<string>();
    public List<string> currentActsDescription2 = new List<string>();
    public List<string> currentSkills = new List<string>();
    public List<string> currentSkillsDescription = new List<string>();
    public List<string> currentItems = new List<string>();
    public List<string> currentItemsDescription = new List<string>();
    public List<string> currentActs = new List<string>();
    public List<string> currentActsDescription = new List<string>();
    public List<string> currentDodges = new List<string>();
    public List<Sprite> enemySprites = new List<Sprite>();

    [Header ("Music")]
    public AudioSource source;
    public AudioClip clip;
    public AudioClip bossMusic;


    public void EnemySelect(){
        for(int i = 0; i < encounterHandlerScript.encounter.Count; i++){
            for(int j = 0; j < enemySystem.enemies.Count; j++){
                if(encounterHandlerScript.encounter[i] == enemySystem.enemies[j].name){
                    currentEnemies.Add(enemySystem.enemies[j].name);
                    currentActs1.Add(enemySystem.enemies[j].act1);
                    currentActs2.Add(enemySystem.enemies[j].act2);
                    currentActsDescription1.Add(enemySystem.enemies[j].act1Description);
                    currentActsDescription2.Add(enemySystem.enemies[j].act2Description);
                    enemyAtk.Add(enemySystem.enemies[j].atk);
                    enemyDef.Add(enemySystem.enemies[j].def);
                    enemyMaxHp.Add(enemySystem.enemies[j].hp);
                    enemyHp.Add(enemySystem.enemies[j].hp);
                    enemySprites.Add(enemySystem.enemies[j].sprite);
                    currentDodges.Add(enemySystem.enemies[j].dodge1);
                    currentDodges.Add(enemySystem.enemies[j].dodge2);
                    if(encounterHandlerScript.isBoss == true)
                        clip = bossMusic;
                    else
                        clip = enemySystem.enemies[j].music;
                }
            }
            isSpared.Add(false);
            isDead.Add(false);
            enemyFp.Add(0);
        }
        playerAtk = playerStatsHandler.playerAtk;
        playerDef = playerStatsHandler.playerDef;
        playerHp = playerStatsHandler.playerHp;
        playerMaxHp = playerStatsHandler.playerMaxHp;
        playerChar = playerStatsHandler.playerChar;
        playerGa = playerStatsHandler.playerGa;
        playerIframe = playerStatsHandler.playerIframe;
        playerLuck = playerStatsHandler.playerLuck;
        playerLvl = playerStatsHandler.playerLvl;
        watt = 0f;
        allDead = false;
        allSpared = false;
        for(int i = 0; i < playerStatsHandler.playerSkills.Count; i++){
            currentSkills.Add(playerStatsHandler.playerSkills[i]);
            currentSkillsDescription.Add(playerStatsHandler.playerSkillsDescription[i]);
        }
        for(int i = 0; i < playerStatsHandler.playerItems.Count; i++){
            currentItems.Add(playerStatsHandler.playerItems[i]);
            currentItemsDescription.Add(playerStatsHandler.playerItemsDescription[i]);
        }
        for(int i = 0; i < currentEnemies.Count; i++){
            enemyFp[i] = 0;
            enemyHp[i] = enemyMaxHp[i];
            isSpared[i] = false;
            isDead[i] = false;
        }
        source.clip = clip;
        source.Play();
        currentPhase = "player";
    }
    

    void Start () 
    {
        encounterHandlerScript = FindObjectOfType<encounterHandlerScript>();
        playerStatsHandler = FindObjectOfType<playerStatsHandler>();
        EnemySelect();
        Screen.SetResolution(1778, 999, true);

    }

    void Update()
    {   
        if(currentPhase == "player"){
            player.SetActive(false);
            if(currentSelected == "menu" || currentSelected == "fightSelect" || currentSelected == "actSelect" || currentSelected == "skillSelect"){
                if(currentButtonSelect > 0 && Input.GetKeyUp(KeyCode.LeftArrow))
                    currentButtonSelect--;
                if(currentButtonSelect < maxSelect && Input.GetKeyUp(KeyCode.RightArrow)) 
                    currentButtonSelect++;
            }
            if(currentSelected == "act" || currentSelected == "skill" || currentSelected == "item"){
                if(currentButtonSelect % 2 == 0 && currentPage > 0 && Input.GetKeyUp(KeyCode.LeftArrow)) {
                    currentButtonSelect++;
                    currentPage--;
                    maxSelect = 3;
                    return;
                }
                if(currentButtonSelect % 2 == 1 && Input.GetKeyUp(KeyCode.LeftArrow))
                    currentButtonSelect--;
                if(currentButtonSelect % 2 == 1 && currentPage < maxPage && Input.GetKeyUp(KeyCode.RightArrow)) {
                    if(currentPage == (maxPage - 1) && (currentItems.Count % 4) - 1 < (currentButtonSelect - 1))

                        currentButtonSelect = 0;
                    else
                        currentButtonSelect--;
                    currentPage++;
                    if(((currentPage + 1 ) * 4) - 1 < currentItems.Count)
                        maxSelect = 3;
                    else
                        maxSelect = 4 - (((currentPage + 1) * 4) - (currentItems.Count - 1));
                    return;
                }
                if(currentButtonSelect % 2 == 0 && currentButtonSelect < maxSelect && Input.GetKeyUp(KeyCode.RightArrow)) 
                    currentButtonSelect++;
                if(currentButtonSelect > 1 && Input.GetKeyUp(KeyCode.UpArrow)) 
                    currentButtonSelect -= 2;
                if(currentButtonSelect < (maxSelect - 1) && Input.GetKeyUp(KeyCode.DownArrow)) 
                    currentButtonSelect += 2;
            }
            if(currentSelected == "fightSelect" || currentSelected == "actSelect"){
                    if(currentEnemies.Count == 1){
                        selectButton();
                    }
                }
            if(Input.GetKeyUp(KeyCode.Z)){
                selectButton();
            }
            if(Input.GetKeyUp(KeyCode.X)){
                backInMenu();
            }
        }
        if(currentPhase == "enemy"){
            player.SetActive(true);
            if (canBeHit == true){
                playerSprite.color = new Color(255,255,255,1f);
            }
            if(takingDamage == true){
                if(canBeHit == true){
                    if(currentEnemies.Count == 1){
                        playerHp -= 10*enemyAtk[0]/playerDef;
                    }
                    else
                        playerHp -= 10*enemyAtk[enemyAttacking]/playerDef;
                    playerSprite.color = new Color(255,255,255,0.5f);
                    canBeHit = false;
                }
            }
        if(Input.GetKeyUp(KeyCode.Q))
        canBeHit = false;
        }
        for(int i = 0; i < enemyFp.Count; i++){
            if(enemyFp[i] > 100f)
                enemyFp[i] = 100f;
        }
        if(playerHp <= 0)
            SceneManager.LoadScene(0);
        for(int i = 0; i < currentEnemies.Count; i++){
            if(enemyHp[i] <= 0){
                isDead[i] = true;
                enemyHp[i] = 0;
            }
            if(isDead[i] == false)
                allDead = false;
            if(isSpared[i] == false)
                allSpared = false;
        if(allDead == true || allSpared == true || currentEnemies.Count == 0)
            SceneManager.LoadScene(0);
        }
        allDead = true;
        allSpared = true;
    }
    

    public void selectButton () 
    {
        switch (currentSelected){
        case "fight":
            fightUsed(currentButtonSelect);
            currentPhase = "enemy";
            break;
        case "fightSelect":
            if(isDead[currentButtonSelect] == false && isDead[currentButtonSelect] == false){
                enemyTargeted = currentButtonSelect; 
                fightUsed(currentButtonSelect);
                currentPhase = "enemy";
            }
            break;
        case "act":
            if(currentPhase == "player")
                actHandlerScript.useAct(currentActs[currentButtonSelect]);
            break;
        case "actSelect":
            if(isDead[currentButtonSelect] == false && isDead[currentButtonSelect] == false){
                enemyTargeted = currentButtonSelect; 
                maxSelect = 3;
                currentSelected = "act";
            }
            break;
        case "skillSelect":
            if(isDead[currentButtonSelect] == false && isDead[currentButtonSelect] == false){
                enemyTargeted = currentButtonSelect; 
                skillHandlerScript.useSkill(skillHandlerScript.currentSkill + " finish");
                currentPhase = "enemy";
            }
            break; 
        case "skill":
            skillHandlerScript.useSkill(currentSkills[currentButtonSelect]);
            break; 
        case "item":
            itemHandlerScript.useItem(currentItems[currentButtonSelect + 4 * currentPage]);
            currentItems.RemoveAt(currentButtonSelect + 4 * currentPage);
            playerStatsHandler.playerItems.RemoveAt(currentButtonSelect + 4 * currentPage);
            playerStatsHandler.playerItemsDescription.RemoveAt(currentButtonSelect + 4 * currentPage);
            currentPhase = "enemy";
            break;
        case "menu":
            switch (currentButtonSelect){
                case 0:
                    currentSelected = "fightSelect";
                    maxSelect = currentEnemies.Count - 1;
                break;
                case 1:
                    currentSelected = "actSelect";
                    maxSelect = currentEnemies.Count - 1;
                break;
                case 2:
                    currentSelected = "skill";
                    maxSelect = currentSkills.Count - 1;
                break;
                case 3:
                    currentSelected = "item";
                    if(currentItems.Count > 3)
                        maxSelect = 3;
                    else
                        maxSelect = currentItems.Count - 1;
                        maxPage = (currentItems.Count - 1) / 4;
                break;
            }
            break;
        }
            for(int i = 0; i < enemySystem.enemies.Count; i++){
                if(isDead[enemyTargeted] == true || isSpared[enemyTargeted] == true){
                    if(currentEnemies[enemyTargeted] == enemySystem.enemies[i].name){
                        currentDodges.Remove(enemySystem.enemies[i].dodge1);
                        currentDodges.Remove(enemySystem.enemies[i].dodge2);
                    }
                }
            }
        currentButtonSelect = 0;
        if(currentPhase == "enemy"){
            maxSelect = 3;
            startEnemyPhase();
        }
    }

    public void startEnemyPhase()
    {
        dodgeSelected = currentDodges[Random.Range(0, currentDodges.Count)];
        
        for(int j = 0; j < enemySystem.enemies.Count; j++){
            for(int i = 0; i < currentEnemies.Count; i++){
                if(dodgeSelected == enemySystem.enemies[j].dodge1 || dodgeSelected == enemySystem.enemies[j].dodge2){
                    if(currentEnemies[i] == enemySystem.enemies[j].name)
                    enemyAttacking = 1;
                }
            }
        }
        dodgeHandlerScript.InitiateDodge(dodgeSelected);
        //dodgeHandlerScript.InitiateDodge("test");
        currentSelected = "menu";
    }


    void backInMenu ()
    {
        currentButtonSelect = 0;
        switch (currentSelected){
            case "actSelect":
                currentSelected = "menu";
                maxSelect = 3;
                break;
            case "act":
                currentSelected = "actSelect";
                maxSelect = currentEnemies.Count - 1;
                break;
            case "fightSelect":
                currentSelected = "menu";
                maxSelect = 3;
                break;
            case "skill":
                currentSelected = "menu";
                maxSelect = 3;
                break;
            case "skillSelect":
                currentSelected = "skill";
                maxSelect = currentSkills.Count - 1;
                break;
            case "item":
                currentSelected = "menu";
                maxSelect = 3;
                break;
        }
    }

    public void existEnemyPhase ()
    {
        if(currentPhase == "enemy"){
        currentSelected = "menu";
        maxSelect = 3;
        currentPhase = "player";
        }

    }
    void fightUsed (int enemySelected)
    {
        enemyHp[enemySelected] -= 10*playerAtk/enemyDef[enemySelected];
        currentPhase = "enemy";
    }
    void FixedUpdate (){
        if(canBeHit == false){
        IframeDuration += Time.fixedDeltaTime;
        }
        if (IframeDuration > playerIframe){
            canBeHit = true;
            IframeDuration = 0f;
        }
        if(gracing == true){
            if(watt < 100)
            watt += (int) 10*Time.fixedDeltaTime;
        }
        
    }
}
