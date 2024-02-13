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

    public GameObject enemySelectMenu1;
    public GameObject enemySelectMenu2;
    public GameObject enemySelectMenu3;
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

    public List<TextMeshProUGUI> enemyOptionsTexts1 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyOptionsTexts2 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyOptionsTexts3 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyStatTexts1 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyStatTexts2 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyStatTexts3 = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyStatTexts1Check = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyStatTexts2Check = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> enemyStatTexts3Check = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> optionsTexts = new List<TextMeshProUGUI>();
    public TextMeshProUGUI descriptionText;
    public List<GameObject> enemySprites1 = new List<GameObject>();
    public List<GameObject> enemySprites2 = new List<GameObject>();
    public List<GameObject> enemySprites3 = new List<GameObject>();
    public GameObject enemySprite;
    

    public int maxItemSelect;


    void Start()
    {
        enemySelectMenu1.SetActive(false);
        enemySelectMenu2.SetActive(false);
        enemySelectMenu3.SetActive(false);
    }

    
    void Update()
    {
        
        if(battleHandlerScript.currentPhase == "player"){
            endGameButton.SetActive(false);
            endGameText.text = " "; 
            battleArea.SetActive(false);
            playerStats.SetActive(false);
            playerHp.text = battleHandlerScript.playerHp + "/" + battleHandlerScript.playerMaxHp;
            playerLvl.text = "" + battleHandlerScript.playerLvl;
            playerWatt.text = Mathf.Floor(battleHandlerScript.watt) + "%";
            if(battleHandlerScript.currentSelected == "menu"){
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
            if(battleHandlerScript.currentSelected == "fightSelect" || battleHandlerScript.currentSelected == "actSelect" || battleHandlerScript.currentSelected == "skillSelect" || battleHandlerScript.currentSelected == "menu"){
                switch(battleHandlerScript.currentEnemies.Count){
                    case 1:
                        enemySelectMenu1.SetActive(true);
                        for(int i = 0; i < battleHandlerScript.currentEnemies.Count; i++){
                            if(battleHandlerScript.isSpared[i] == true)
                                enemyOptionsTexts1[i].text = ":) " + battleHandlerScript.currentEnemies[i];  
                            else{
                                if(battleHandlerScript.isDead[i] == true)
                                    enemyOptionsTexts1[i].text = "X( " + battleHandlerScript.currentEnemies[i];  
                                else
                                    enemyOptionsTexts1[i].text = battleHandlerScript.currentEnemies[i];  
                            }
                            enemySprites1[i].GetComponent<UnityEngine.UI.Image>().sprite = battleHandlerScript.enemySprites[i];
                            if(i == battleHandlerScript.currentButtonSelect && battleHandlerScript.currentSelected != "menu")
                                enemyOptionsTexts3[i].color = Color.yellow;
                            else
                                enemyOptionsTexts3[i].color = Color.white;
                            enemyStatTexts1[i].text = battleHandlerScript.enemyHp[i] + "/" + battleHandlerScript.enemyMaxHp[i] + "\n" + battleHandlerScript.enemyFp[i] + "%";
                            if(battleHandlerScript.isChecked[i] == true)
                                enemyStatTexts1Check[i].text = "ATK: " + battleHandlerScript.enemyAtk[i] + "\n" + "DEF: " + battleHandlerScript.enemyDef[i];
                            else
                                enemyStatTexts1Check[i].text = " ";
                            
                        }
                        break;
                    case 2:
                        enemySelectMenu2.SetActive(true);
                        for(int i = 0; i < battleHandlerScript.currentEnemies.Count; i++){
                            if(battleHandlerScript.isSpared[i] == true)
                                enemyOptionsTexts2[i].text = ":) " + battleHandlerScript.currentEnemies[i];  
                            else{
                                if(battleHandlerScript.isDead[i] == true)
                                    enemyOptionsTexts2[i].text = "X( " + battleHandlerScript.currentEnemies[i];  
                                else
                                    enemyOptionsTexts2[i].text = battleHandlerScript.currentEnemies[i];  
                            }
                            enemySprites2[i].GetComponent<UnityEngine.UI.Image>().sprite = battleHandlerScript.enemySprites[i];
                            if(i == battleHandlerScript.currentButtonSelect && battleHandlerScript.currentSelected != "menu")
                                enemyOptionsTexts3[i].color = Color.yellow;
                            else
                                enemyOptionsTexts3[i].color = Color.white;
                            enemyStatTexts2[i].text = battleHandlerScript.enemyHp[i] + "/" + battleHandlerScript.enemyMaxHp[i] + "\n" + battleHandlerScript.enemyFp[i] + "%";
                            if(battleHandlerScript.isChecked[i] == true)
                                enemyStatTexts2Check[i].text = "ATK: " + battleHandlerScript.enemyAtk[i] + "\n" + "DEF: " + battleHandlerScript.enemyDef[i];
                            else
                                enemyStatTexts2Check[i].text = " ";
                        }
                        break;
                    case 3:
                        enemySelectMenu3.SetActive(true);
                        for(int i = 0; i < battleHandlerScript.currentEnemies.Count; i++){
                            if(battleHandlerScript.isSpared[i] == true)
                                enemyOptionsTexts3[i].text = ":) " + battleHandlerScript.currentEnemies[i];  
                            else{
                                if(battleHandlerScript.isDead[i] == true)
                                    enemyOptionsTexts3[i].text = "X( " + battleHandlerScript.currentEnemies[i];  
                                else
                                    enemyOptionsTexts3[i].text = battleHandlerScript.currentEnemies[i];  
                            }
                            enemySprites3[i].GetComponent<UnityEngine.UI.Image>().sprite = battleHandlerScript.enemySprites[i];
                            if(i == battleHandlerScript.currentButtonSelect && battleHandlerScript.currentSelected != "menu") 
                                enemyOptionsTexts3[i].color = Color.yellow;
                            else
                                enemyOptionsTexts3[i].color = Color.white;
                            enemyStatTexts3[i].text = battleHandlerScript.enemyHp[i] + "/" + battleHandlerScript.enemyMaxHp[i] + "\n" + battleHandlerScript.enemyFp[i] + "%";
                            if(battleHandlerScript.isChecked[i] == true)
                                enemyStatTexts3Check[i].text = "ATK: " + battleHandlerScript.enemyAtk[i] + "\n" + "DEF: " + battleHandlerScript.enemyDef[i];
                            else
                                enemyStatTexts3Check[i].text = " ";
                        }
                        break;  
                }                     
            }
            if(battleHandlerScript.currentSelected == "fight"){
                enemySelectMenu1.SetActive(false);
                enemySelectMenu2.SetActive(false);
                enemySelectMenu3.SetActive(false);
                fightMinigame.SetActive(true);
            }
            if(battleHandlerScript.currentSelected == "act" || battleHandlerScript.currentSelected == "skill" || battleHandlerScript.currentSelected == "item"){
                enemySelectMenu1.SetActive(false);
                enemySelectMenu2.SetActive(false);
                enemySelectMenu3.SetActive(false);
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
                        descriptionText.text = battleHandlerScript.currentItemsDescription[battleHandlerScript.currentButtonSelect + 4 * battleHandlerScript.currentPage];
                        break;
                }
                enemySprite.GetComponent<UnityEngine.UI.Image>().sprite = battleHandlerScript.enemySprites[battleHandlerScript.enemyTargeted];
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
            enemySelectMenu1.SetActive(false);
            enemySelectMenu2.SetActive(false);
            enemySelectMenu3.SetActive(false);
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
            enemySelectMenu1.SetActive(false);
            enemySelectMenu2.SetActive(false);
            enemySelectMenu3.SetActive(false);
            actSkillItemMenu.SetActive(false);
            fightMinigame.SetActive(false);
            endGameButton.SetActive(true);
            endGameText.text = "win! jippie!";
        }
        if(battleHandlerScript.currentPhase == "ded"){
            actMinigame.SetActive(false);
            enemySelectMenu1.SetActive(false);
            enemySelectMenu2.SetActive(false);
            enemySelectMenu3.SetActive(false);
            actSkillItemMenu.SetActive(false);
            fightMinigame.SetActive(false);
            endGameButton.SetActive(true);
            endGameText.text = "dead, oops";
        }
    }
}
