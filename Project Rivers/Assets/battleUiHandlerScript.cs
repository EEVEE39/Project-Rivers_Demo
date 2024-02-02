using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class battleUiHandlerScript : MonoBehaviour
{
    public battleHandlerScript battleHandlerScript;
    public Sprite fightSelected;
    public Sprite actSelected;
    public Sprite skillSelected;
    public Sprite itemSelected;
    public Sprite epmtySprite;

    public GameObject enemySelectMenu;
    public GameObject actSkillItemMenu;
    public GameObject fightMinigame;
    public GameObject actMinigame;
    public GameObject playerStats;
    public GameObject battleArea;

    public TextMeshProUGUI playerHp;
    public TextMeshProUGUI playerLvl;
    public TextMeshProUGUI playerWatt;
    public TextMeshProUGUI battlePlayerHp;
    public TextMeshProUGUI battlePlayerLvl;
    public TextMeshProUGUI battlePlayerWatt;

    public TextMeshProUGUI endGameText;
    public GameObject endGameButton;

    public List<TextMeshProUGUI> enemyOptionsTexts = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyStatTexts = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> optionsTexts = new List<TextMeshProUGUI>();
    public TextMeshProUGUI descriptionText;
    

    public int maxItemSelect;


    void Start()
    {
    }

    
    void Update()
    {
        
        if(battleHandlerScript.currentPhase == "player"){
            endGameButton.SetActive(false);
            endGameText.text = " ";
            gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = fightSelected;
            battleArea.SetActive(false);
            playerStats.SetActive(false);
            playerHp.text = battleHandlerScript.playerHp + "/" + battleHandlerScript.playerMaxHp;
            playerLvl.text = "" + battleHandlerScript.playerLvl;
            playerWatt.text = Mathf.Floor(battleHandlerScript.watt) + "%";
            
            if(battleHandlerScript.currentSelected == "menu"){
                enemySelectMenu.SetActive(false);
                actSkillItemMenu.SetActive(true);
                fightMinigame.SetActive(false);
                for(int i = 0; i < optionsTexts.Count; i++){
                optionsTexts[i].text = " ";
                }
                descriptionText.text = " ";
                switch (battleHandlerScript.currentButtonSelect){
                    case 0:
                        gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = fightSelected;
                        break;
                    case 1:
                        gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = actSelected;
                        break;
                    case 2:
                        gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = skillSelected;
                        break;
                    case 3:
                        gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = itemSelected;
                        break;
                }
            }
            if(battleHandlerScript.currentSelected == "fightSelect" || battleHandlerScript.currentSelected == "actSelect" || battleHandlerScript.currentSelected == "skillSelect"){
                enemySelectMenu.SetActive(true);
                for(int i = 0; i < battleHandlerScript.currentEnemies.Count; i++){
                    if(battleHandlerScript.isSpared[i] == true)
                        enemyOptionsTexts[i].text = ":) " + battleHandlerScript.currentEnemies[i];  
                    else{
                        if(battleHandlerScript.isDead[i] == true)
                            enemyOptionsTexts[i].text = "X( " + battleHandlerScript.currentEnemies[i];  
                        else
                            enemyOptionsTexts[i].text = battleHandlerScript.currentEnemies[i];  
                    }
                    
                    if(i == battleHandlerScript.currentButtonSelect) 
                        enemyOptionsTexts[i].color = Color.yellow;
                    else
                        enemyOptionsTexts[i].color = Color.white;
                    enemyStatTexts[i].text = battleHandlerScript.enemyHp[i] + "\n" + battleHandlerScript.enemyFp[i];
                }                   
            }
            if(battleHandlerScript.currentSelected == "fight"){
                enemySelectMenu.SetActive(false);
                fightMinigame.SetActive(true);
            }
            if(battleHandlerScript.currentSelected == "act" || battleHandlerScript.currentSelected == "skill" || battleHandlerScript.currentSelected == "item"){
                enemySelectMenu.SetActive(false);
                actSkillItemMenu.SetActive(true);
                for(int i = 0; i < optionsTexts.Count; i++){
                    optionsTexts[i].text = " ";
                    if(i == battleHandlerScript.currentButtonSelect) 
                    optionsTexts[i].color = Color.yellow;
                    else
                    optionsTexts[i].color = Color.white;
                }
                switch (battleHandlerScript.currentSelected){
                    case "act":
                        for(int i = 0; i < battleHandlerScript.currentEnemies.Count; i++)
                        if (i == battleHandlerScript.enemyTargeted){
                            battleHandlerScript.currentActs[2] = battleHandlerScript.currentActs1[i];
                            battleHandlerScript.currentActs[3] = battleHandlerScript.currentActs2[i];
                            battleHandlerScript.currentActsDescription[2] = battleHandlerScript.currentActsDescription1[i];
                            battleHandlerScript.currentActsDescription[3] = battleHandlerScript.currentActsDescription2[i];
                        }
                        for(int i = 0; i < battleHandlerScript.currentActs.Count; i++)
                        optionsTexts[i].text = battleHandlerScript.currentActs[i];
                        descriptionText.text = battleHandlerScript.currentActsDescription[battleHandlerScript.currentButtonSelect];
                        break;
                    case "skill":
                        for(int i = 0; i < battleHandlerScript.currentSkills.Count; i++)
                            optionsTexts[i].text = battleHandlerScript.currentSkills[i];
                        descriptionText.text = battleHandlerScript.currentSkillsDescription[battleHandlerScript.currentButtonSelect];
                        break;
                    case "item":
                        if((battleHandlerScript.currentPage + 1) * 4 <= battleHandlerScript.currentItems.Count)
                            maxItemSelect = 4;
                        else
                            maxItemSelect = 4 - ((battleHandlerScript.currentPage + 1) * 4 - battleHandlerScript.currentItems.Count); 
                        for(int i = 0; i < maxItemSelect; i++){
                            optionsTexts[i].text = battleHandlerScript.currentItems[i + 4 * battleHandlerScript.currentPage];
                        }   
                        descriptionText.text = battleHandlerScript.currentItemsDescription[battleHandlerScript.currentButtonSelect];
                        break;
                }
            }
            if(battleHandlerScript.currentSelected == "actMinigame"){
                playerHp.text = " ";
                playerLvl.text = " ";
                playerWatt.text = " ";
                actMinigame.SetActive(true);
                playerStats.SetActive(true);
                actSkillItemMenu.SetActive(false);
            }
            else{
                actMinigame.SetActive(false);
            }
        }
        if(battleHandlerScript.currentPhase == "enemy"){
            actMinigame.SetActive(false);
            battleArea.SetActive(true);
            playerStats.SetActive(true);
            enemySelectMenu.SetActive(false);
            actSkillItemMenu.SetActive(false);
            fightMinigame.SetActive(false);
            playerHp.text = " ";
            playerLvl.text = " ";
            playerWatt.text = " ";
            for(int i = 0; i < optionsTexts.Count; i++){
                optionsTexts[i].text = " ";
            }
            descriptionText.text = " ";
            battlePlayerHp.text = battleHandlerScript.playerHp + "/" + battleHandlerScript.playerMaxHp;
            battlePlayerLvl.text = "" + battleHandlerScript.playerLvl;
            battlePlayerWatt.text = Mathf.Floor(battleHandlerScript.watt) + "%";

            gameObject.GetComponent<UnityEngine.UI.Image> ().sprite = epmtySprite;
        }
        if(battleHandlerScript.currentPhase == "win"){
            actMinigame.SetActive(false);
            enemySelectMenu.SetActive(false);
            actSkillItemMenu.SetActive(false);
            fightMinigame.SetActive(false);
            endGameButton.SetActive(true);
            endGameText.text = "win! jippie!";
        }
        if(battleHandlerScript.currentPhase == "ded"){
            actMinigame.SetActive(false);
            enemySelectMenu.SetActive(false);
            actSkillItemMenu.SetActive(false);
            fightMinigame.SetActive(false);
            endGameButton.SetActive(true);
            endGameText.text = "dead, oops";
        }
    }
}
