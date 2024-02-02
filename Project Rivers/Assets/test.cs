using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class test : MonoBehaviour
{
    public TextMeshProUGUI tempText;
    public battleHandlerScript battleHandlerScript;

    void Update (){
        tempText.text = "" + battleHandlerScript.enemyFp[0];
    }
}
