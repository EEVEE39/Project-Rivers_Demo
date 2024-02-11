using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatsHandler : MonoBehaviour
{
    public List<string> playerSkills = new List<string>();
    public List<string> playerSkillsDescription = new List<string>();
    public List<string> playerItems = new List<string>();
    public List<string> playerItemsDescription = new List<string>();
    public int playerMaxHp;
    public int playerHp;
    public int playerDef;
    public int playerAtk;
    public int playerChar;
    public int playerGa;
    public int playerIframe;
    public int playerLuck;
    public int playerLvl;

    void Start(){
        DontDestroyOnLoad(gameObject);
    }
}
