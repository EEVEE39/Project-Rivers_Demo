using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialougeManager : MonoBehaviour
{

    public List<string> sentences = new List<string>();
    public List<string> enemies = new List<string>();

    public GameObject dialougeBox;
    public TextMeshProUGUI dialougeText;
    public TextMeshProUGUI nameText;

    public int currentSentence;
    public bool dialouging;

    void Start()
    {
        dialougeBox.SetActive(false);
    }

    public void startDialouge (Dialouge dialouge)
    {
        sentences.Clear();
        for(int i = 0; i < dialouge.sentences.Count; i++){
            sentences.Add(dialouge.sentences[i]);
        }
        for(int i = 0; i < dialouge.enemies.Count; i++){
            enemies.Add(dialouge.enemies[i]);
        }
        Debug.Log("KAnker");
        currentSentence = 0;
        dialouging = true;
        dialougeBox.SetActive(true);
        nameText.text = dialouge.name;
        FindObjectOfType<PlayerMovement>().moveSpeed = 0;
        dialougeBox.GetComponent<UnityEngine.UI.Image>().sprite = dialouge.sprite;
        
    }

    public void endDialouge(){
        FindObjectOfType<PlayerMovement>().moveSpeed = 3;
        if(enemies.Count > 0){
            FindObjectOfType<encounterHandlerScript>().StartBattle(enemies);
        }
        if(enemies.Count == 3){
            FindObjectOfType<encounterHandlerScript>().isBoss = true;
        }
        dialouging = false;
        dialougeBox.SetActive(false);
    }

    void Update(){
        if(dialouging == true){
            dialougeText.text = sentences[currentSentence];
            if(Input.GetKeyUp(KeyCode.Z)){
                currentSentence++;
                return; 
            }
        }
        if(currentSentence >= sentences.Count - 1)
            endDialouge();
    }
}
