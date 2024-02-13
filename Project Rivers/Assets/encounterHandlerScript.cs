using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class encounterHandlerScript : MonoBehaviour
{
    public battleHandlerScript battleHandlerScript;
    public dialougeManager dialougeManager;
    public List<string> encounter = new List<string>();
    public bool isBoss;

    public bool gilliganWin;
    public bool germaWin;
    public bool jeffWin;

    
    


    public void StartBattle(List<string> enemies = null){
        encounter.Clear();
        for(int i = 0; i < enemies.Count; i++)
            encounter.Add(enemies[i]);
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }
    void Update(){
    //Debug.Log(encounter.Count);
    }
}
